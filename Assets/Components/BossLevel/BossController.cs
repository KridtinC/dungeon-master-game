using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public Rigidbody rb;

    private float defaultY;

    protected override void Start() {
        defaultY = transform.position.y;
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        checkStat();
        checkPosition();
    }

    protected bool IsInside = false;
    protected void checkStat() {
        if (hp <= 0) {
            Destroy(gameObject);
        }
        if (Inside()) {
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
            if (OnTop()) {
                IsStamping = 1;
                return;
            }
        }
        if (IsStamping == 1) {
            if (TouchFloor()) {
                rb.velocity = Vector3.zero;
                IsStamping = 2;
            } else {
                rb.AddForce(-transform.up * 50);
            }
            return;
        } else if (IsStamping == 2) {
            if (transform.position.y > defaultY) {
                rb.velocity = Vector3.zero;
                if (!OnTop()) {
                    IsStamping = 0;
                }
            } else {
                rb.AddForce(transform.up * 50);
            }
            return;
        } 
        
        Follow();
    }

    public bool OnTop() {
        Vector3 position = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 scale = GetComponent<Renderer>().bounds.size;
        return 
            (position.x - scale.x/2 <= playerPos.x && playerPos.x <= position.x + scale.x/2)
            && (position.z - scale.z/2 <= playerPos.z && playerPos.z <= position.z + scale.z/2);
    }

    public bool Inside() {
        Vector3 position = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 scale = GetComponent<Renderer>().bounds.size;
        return OnTop() 
            && (position.y - scale.y/2 <= playerPos.y && playerPos.y <= position.y + scale.y/2);
    }

    protected bool TouchFloor() {
        Vector3 position = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 scale = GetComponent<Renderer>().bounds.size;
        Vector3 playerScale = player.GetComponent<Renderer>().bounds.size;
        return position.y - scale.y/2 < playerPos.y - playerScale.y;
    }
}
