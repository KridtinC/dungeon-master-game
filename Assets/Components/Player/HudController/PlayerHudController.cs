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
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        float hp = player.GetHP();
        float maxHp = player.GetMaxHP();
        healthBar.value = hp;
        attack.text = player.GetAttack().ToString();
        money.text = player.GetMoney().ToString();

        if (maxHp / 4 < hp && hp <= maxHp / 2)
        {
            health.color = Color.yellow;
        }
        else if (hp <= maxHp / 4)
        {
            health.color = Color.red;
        }
    }
}
