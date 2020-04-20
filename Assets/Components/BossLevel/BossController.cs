﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public EnemyController enemyObject;
    public GameObject bombObject;
    protected EnemyController[] enemyObjs;
    protected int enemyCount = 5;
    protected int deadCount = 0;

    private float defaultY;

    protected bool IsPhase1() { return true; }
    protected bool IsPhase2() { return this.GetHP() < 66f; }
    protected bool IsPhase3() { return this.GetHP() < 33f; }

    protected override void Start() {
        enemyObjs = new EnemyController[enemyCount];
        enemyObject.gameObject.SetActive(false);
        bombObject.gameObject.SetActive(false);
        defaultY = transform.position.y;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        checkStat();
        checkPosition();
        if (IsPhase2()) shootBullet();
        if (IsPhase3()) raining();
    }

    protected bool IsInside = false;
    protected void checkStat() {
        if (hp <= 0) {
            Destroy(gameObject);
        }

        for (int i = 0; i < enemyCount; ++i) {
            if (enemyObjs[i] == null) {
                EnemyController newEnemy = Instantiate(enemyObject);
                newEnemy.gameObject.SetActive(true);
                newEnemy.transform.position = transform.position;
                newEnemy.rb.useGravity = true;

                // Add force
                Vector3 rotation = Quaternion.AngleAxis(Random.Range(0, 360f), Vector3.up) * Vector3.forward;
                Vector3 forceVec = Quaternion.AngleAxis(Random.Range(-15f, 15f), rotation) * Vector3.up;
                newEnemy.rb.AddForce(20 * forceVec, ForceMode.Impulse);

                enemyObjs[i] = newEnemy;
                break;
            } else if (enemyObjs[i].GetHP() <= 0) {
                deadCount += 1;
                if (deadCount % 5 == 0) {
                    GameObject bomb = Instantiate(bombObject);
                    bomb.gameObject.SetActive(true);
                    bomb.transform.position = enemyObjs[i].transform.position;
                }
                Destroy(enemyObjs[i]);
                enemyObjs[i] = null;
            }
        }

        if (Inside(player.gameObject)) {
            if (!IsInside) {
                player.OnAttack(player.GetMaxHP() / 3);
            }
            IsInside = true;
        } else {
            IsInside = false;
        }
    }

    protected int IsStamping = 0;
    protected void checkPosition() {
        if (IsStamping == 0) {
            if (OnTop(player.gameObject)) {
                IsStamping = 1;
                return;
            }
        }
        if (IsStamping == 1) {
            if (TouchFloor()) {
                rb.velocity = Vector3.zero;
                IsStamping = 2;

                // Check if damage
                foreach (GameObject bomb in GameObject.FindGameObjectsWithTag("Bomb")) {
                    if (bomb.gameObject.activeSelf && OnTop(bomb.gameObject)) {
                        OnAttack(10);
                        Destroy(bomb);
                    }
                }
            } else {
                rb.AddForce(-transform.up * 50);
            }
            return;
        } else if (IsStamping == 2) {
            if (transform.position.y > defaultY) {
                rb.velocity = Vector3.zero;
                if (!OnTop(player.gameObject)) {
                    IsStamping = 0;
                }
            } else {
                rb.AddForce(transform.up * 50);
            }
            return;
        } 
        
        Follow();
    }

    public bool OnTop(GameObject obj) {
        Vector3 position = transform.position;
        Vector3 objPos = obj.transform.position;
        Vector3 scale = GetComponent<Renderer>().bounds.size;
        return 
            (position.x - scale.x/2 <= objPos.x && objPos.x <= position.x + scale.x/2)
            && (position.z - scale.z/2 <= objPos.z && objPos.z <= position.z + scale.z/2);
    }

    public bool Inside(GameObject obj) {
        Vector3 position = transform.position;
        Vector3 objPos = obj.transform.position;
        Vector3 scale = GetComponent<Renderer>().bounds.size;
        return OnTop(obj) 
            && (position.y - scale.y/2 <= objPos.y && objPos.y <= position.y + scale.y/2);
    }

    protected bool TouchFloor() {
        Vector3 position = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 scale = GetComponent<Renderer>().bounds.size;
        Vector3 playerScale = player.GetComponent<Renderer>().bounds.size;
        return position.y - scale.y/2 < playerPos.y - playerScale.y;
    }

    public BossLevelBullet bulletObject;
    protected float bulletTimeCount = 0;
    protected void shootBullet() {
        bulletTimeCount += Time.deltaTime;
        if (bulletTimeCount > 5f) {
            BossLevelBullet bullet = Instantiate(bulletObject);
            bullet.gameObject.transform.position = transform.position + 10 * transform.up;
            bullet.active = true;
            bulletTimeCount = 0.0f;
        }
    }

    public BossLevelRainBullet rainBulletObject;
    protected float rainingTimeCount = 0f;
    protected void raining() {
        rainingTimeCount += Time.deltaTime;
        if (rainingTimeCount > 0.3f) {
            for (int i = 0; i < 3; ++i) {
                BossLevelRainBullet rain = Instantiate(rainBulletObject);
                Vector3 offset =
                    Quaternion.AngleAxis(Random.Range(0f, 360f), gameObject.transform.up)
                    * gameObject.transform.forward
                    * Random.Range(0, 15);
                rain.gameObject.transform.position = 
                    player.gameObject.transform.position
                    + 30 * gameObject.transform.up
                    + offset;
                rain.active = true;
            }
            rainingTimeCount = 0f;
        }
    }
}
