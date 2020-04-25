using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject camera_obj;

    private float hp;
    private float attack;
    private float money;

    protected float maxHp = 100;
    protected float initAttack = 1;
    protected float speed = 5;
    protected float attackRange = 2;
    private List<ItemController> inventory;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
        attack = initAttack;
        money = 0;
        inventory = new List<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 position = transform.position;
        Vector3 direction = (camera_obj)
            ? position - camera_obj.transform.position
            : Vector3.forward;
        direction.y = 0;
        direction = Vector3.Normalize(direction);


        if (Input.GetKey(KeyCode.W))
        {
            position += direction * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 backDirection = Quaternion.AngleAxis(180, Vector3.up) * direction;
            position += backDirection * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 leftDirection = Quaternion.AngleAxis(-90, Vector3.up) * direction;
            position += leftDirection * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 rightDirection = Quaternion.AngleAxis(90, Vector3.up) * direction;
            position += rightDirection * speed * Time.deltaTime;
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

    public void OnPickUpItem(ItemController item)
    {
        if (item is WeaponController)
        {
            attack += ((WeaponController) item).GetAttack();
            attackRange = Mathf.Max(attackRange, ((WeaponController)item).GetRange());
        }
        else if (item is CoinController)
        {
            money += ((CoinController) item).GetValue();
        }
        else
        {
            inventory.Add(item);
        }
    }

    public void OnPlaceItem(int itemIndex, PlaceItemController placeItemArea)
    {
        ItemController item = Instantiate(inventory[itemIndex]);
        item.name = inventory[itemIndex].name;
        item.gameObject.transform.position = placeItemArea.transform.position;
        item.gameObject.SetActive(true);
        inventory.RemoveAt(itemIndex);
    }

    public void OnPlaceItem(int itemIndex, PlaceKeyItemController placeItemArea)
    {
        ItemController item = Instantiate(inventory[itemIndex]);
        item.name = inventory[itemIndex].name;
        item.gameObject.transform.position = placeItemArea.transform.position;
        item.gameObject.SetActive(true);
        inventory.RemoveAt(itemIndex);
    }

    public float GetHP()
    {
        return hp;
    }

    public float GetMaxHP()
    {
        return maxHp;
    }

    public float GetAttack()
    {
        return attack;
    }

    public float GetMoney()
    {
        return money;
    }

    public List<ItemController> GetInventory()
    {
        return inventory;
    }
}
