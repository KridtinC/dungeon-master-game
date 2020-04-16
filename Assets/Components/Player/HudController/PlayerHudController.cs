using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudController : MonoBehaviour
{
    public Slider healthBar;
    public Image health;
    public Text attack;
    public Text money;
    public Text inventory;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
        UpdateInventory();
        attack.text = player.GetAttack().ToString();
        money.text = player.GetMoney().ToString();
    }

    private void UpdateHealthBar()
    {
        float hp = player.GetHP();
        float maxHp = player.GetMaxHP();
        healthBar.value = hp;
        if (maxHp / 4 < hp && hp <= maxHp / 2)
        {
            health.color = Color.yellow;
        }
        else if (hp <= maxHp / 4)
        {
            health.color = Color.red;
        }
    }

    private void UpdateInventory()
    {
        string inv = "";
        foreach(ItemController item in player.GetInventory())
        {
            inv += "- " + item.name + "\n";
        }
        inventory.text = inv;
    }
}
