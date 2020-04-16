using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public PlayerController player;
    protected float dist;

    protected string text = "Press 'E' to pickup.";
    protected bool pickup = false;
    protected float minDist = 2f;

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!pickup)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= minDist && Input.GetKey(KeyCode.E))
            {
                player.OnPickUpItem(this);
                pickup = true;
            }
        }
    }

    void OnGUI()
    {
        if (dist <= minDist && !pickup)
        {
            GUI.TextArea(new Rect(100, 50, 200, 100), text);
        }
    }

    public bool IsPickUp()
    {
        return pickup;
    }
}
