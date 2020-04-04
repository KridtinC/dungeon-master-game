using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHudController : MonoBehaviour
{
    public Slider healthBar;
    public Text attack;
    public Text money;
    public PlayerController player;

    // Update is called once per frame
    void Update()
    {
        healthBar.value = player.GetHP();
        attack.text = player.GetAttack().ToString();
        money.text = player.GetMoney().ToString();
    }
}
