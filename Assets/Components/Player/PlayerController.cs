using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject camera_obj;

    public float hp;
    public float attack;

    protected float maxHp = 100;
    protected float initAttack = 1;
    protected float speed = 5;
    protected float attackRange = 2;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        attack = initAttack;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            position += Vector3.right * speed * Time.deltaTime;
        }

        transform.position = position;

        if (Input.GetKeyDown(KeyCode.G))
        {
            Attack();
        }
    }

    private void Attack()
    {
        EnemyController[] enemy = GameObject.FindObjectsOfType<EnemyController>();
        for (int i = 0; i < enemy.Length; ++i)
        {
            float distance = Vector3.Distance(transform.position, enemy[i].transform.position);
            if (distance <= attackRange)
            {
                enemy[i].OnAttack(attack);
            }
        }
    }

    public void OnAttack(float damage)
    {
        hp = Mathf.Max(0, hp - damage);
    }

    //public void OnPickUpItem(ItemController item)
    //{
    //    if (item is WeaponController)
    //    {
    //        print('yes is weapon');
    //    }
    //    //attack += item.GetAttack();
    //    //attackRange = Mathf.Max(attackRange, item.GetRange());
    //}

    public float GetHP()
    {
        return hp;
    }

    public float GetAttack()
    {
        return attack;
    }
}
