using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public PlayerController player;
    public string Door_key = "";
    protected float dist;
    protected float minDist = 2f;
    private int itemIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
    }

    void OnGUI()
    {
        if (dist <= minDist)
        {
            if (player.GetInventory().Count == 0)
            {
                GUI.TextArea(new Rect(100, 50, 200, 100), "You don't have any item");
            }
            else
            {
                List<ItemController> inventory = player.GetInventory();
                string inv = "";
                string key_word = "";
                for (int i = 0; i < inventory.Count; i++)
                {
                    key_word += inventory[i].name[0];
                    inv += "- " + inventory[i].name + "\n";
                }

                UnityEngine.Debug.Log(key_word);
                UnityEngine.Debug.Log(gameObject.transform.position.y);

                

                if (key_word == Door_key)
                {
                    Destroy(gameObject);
                }
                else
                {
                    GUI.TextArea(new Rect(100, 50, 200, 100), "The Key workd is \n" + Door_key + " not " + key_word);
                    //gameObject.transform.position.y += 20;
                }

            }
        }
    }
}
