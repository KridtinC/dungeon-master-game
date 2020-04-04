using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController player;
    public float hp;
    public float attack;
    private bool isCollide;

    protected float maxHp = 30;
    protected float initAttack = 3;
    protected float speed = 1.5f;
    protected float stepBack = 1.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        attack = initAttack;
        isCollide = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCollide)
        {
            Follow();
        }
        if (hp == 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void Follow()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = transform.position;

        float deltaX = (playerPos - enemyPos).x;
        float deltaZ = (playerPos - enemyPos).z;

        if (deltaX != 0)
        {
            enemyPos += (deltaX / Math.Abs(deltaX)) * Vector3.right * Time.deltaTime * speed;
        }

        if (deltaZ != 0)
        {
            enemyPos += (deltaZ / Math.Abs(deltaZ)) * Vector3.forward * Time.deltaTime * speed;
        }

        transform.position = enemyPos;

    }

    private void OnCollisionEnter(Collision collision) //Attack
    {
        if (collision.gameObject.name == "Player")
        {
            isCollide = true;
            player.OnAttack(attack);

            Vector3 playerPos = player.transform.position;
            Vector3 enemyPos = transform.position;

            float deltaX = (playerPos - enemyPos).x;
            float deltaZ = (playerPos - enemyPos).z;
            Vector3 direction = new Vector3(-deltaX, 0, -deltaZ);
            if (Vector3.Distance(playerPos, enemyPos) < stepBack)
            {
                direction.Normalize();
                transform.position += (direction * stepBack);
            }
        }
    }

    public void OnAttack(float damage)
    {
        hp = Mathf.Max(0, hp - damage);
    }

    private void OnCollisionExit(Collision collision)
    {
        isCollide = false;
    }

    public float GetHP()
    {
        return hp;
    }

    public float GetAttack()
    {
        return attack;
    }
}
