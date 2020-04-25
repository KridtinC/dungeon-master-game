﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKeyItemController : MonoBehaviour
{
    public string Specific;
    private bool isCorrect = false;
    public PlayerController player;
    protected float dist;
    private bool isSelectingItem = false;
    private int itemIndex = 0;

    protected string text = "Press 'E' to place item.";
    protected bool isPlaced = false;
    protected float minDist = 2f;
    private string Key;
    // Update is called once per frame
    void Update()
    {
        if (!isCorrect)
        {
            if (!isPlaced)
            {
                dist = Vector3.Distance(player.transform.position, transform.position);
                if (dist <= minDist && player.GetInventory().Count > 0)
                {
                    if (Input.GetKeyDown(KeyCode.E) && !isSelectingItem)
                        isSelectingItem = true;
                    if (Input.GetKeyDown(KeyCode.DownArrow) && itemIndex < player.GetInventory().Count - 1 && isSelectingItem)
                    {
                        itemIndex += 1;
                    }
                    if (Input.GetKeyDown(KeyCode.UpArrow) && itemIndex > 0 && isSelectingItem)
                    {
                        itemIndex -= 1;
                    }
                    if (Input.GetKey(KeyCode.Space) && isSelectingItem)
                    {
                        Key = player.GetInventory()[itemIndex].name;
                        player.OnPlaceItem(itemIndex, this);
                        isPlaced = true;
                        checkCorrectKey();
                        print("isCorrect" + isCorrect);
                        isSelectingItem = false;
                        itemIndex = 0;
                    }

                }
                else
                {
                    isSelectingItem = false;
                }

            }
            else if (isPlaced)
            {
                if (dist <= minDist && Input.GetKey(KeyCode.E))
                {
                    isPlaced = false;
                    Key = "";
                }
            }

        }
        else
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }
       
        print(itemIndex);
    }

    void checkCorrectKey()
    {
        if(Specific == Key)
        {
            isCorrect = true;
        }
        else
        {
            isCorrect = false;
        }
    }

    public bool getIsCorrect()
    {
        return isCorrect;
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
                if (!isPlaced && !isSelectingItem)
                {
                    GUI.TextArea(new Rect(100, 50, 200, 100), text);
                }
                else if (isSelectingItem)
                {
                    List<ItemController> inventory = player.GetInventory();
                    string inv = "";
                    for (int i = 0; i < inventory.Count; i++)
                    {
                        if (itemIndex == i)
                            inv += "> ";
                        inv += "- " + inventory[i].name + "\n";
                    }
                    GUI.TextArea(new Rect(100, 50, 200, 100), "Select item:\n" + inv);
                }
            }
        }


    }

}
