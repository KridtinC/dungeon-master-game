using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFloorController : MonoBehaviour
{
    public PlayerController player;
    private bool isEnter = false;
    private bool isStepOn = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            player.OnAttack(10f);
            isEnter = false;
            isStepOn = true;
        }
        else if (isStepOn)
        {
            isEnter = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isEnter = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isEnter = false;
    }
}
