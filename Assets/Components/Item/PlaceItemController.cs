using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemController : MonoBehaviour
{
    public PlayerController player;
    protected float dist;

    protected string text = "Press 'E' to place item.";
    protected bool isPlaced = false;
    protected float minDist = 2f;
    private bool isSelectingItem = false;
    private int itemIndex = 0;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (!isPlaced)
        {
            if (dist <= minDist && player.GetInventory().Count > 0)
            {
                if(Input.GetKey(KeyCode.E) && !isSelectingItem)
                    isSelectingItem = true;
                if (Input.GetKey(KeyCode.DownArrow) && itemIndex < player.GetInventory().Count - 1 && isSelectingItem)
                {
                    itemIndex += 1;
                }
                if (Input.GetKey(KeyCode.UpArrow) && itemIndex > 0 && isSelectingItem)
                {
                    itemIndex -= 1;
                }
                if (Input.GetKey(KeyCode.Space) && isSelectingItem)
                {
                    player.OnPlaceItem(itemIndex, this);
                    isPlaced = true;
                    isSelectingItem = false;
                    itemIndex = 0;
                }

            }
            else
            {
                isSelectingItem = false;
            }

        }
        else
        {
            if(dist <= minDist && Input.GetKey(KeyCode.E))
            {
                isPlaced = false;
            }
        }
        print(itemIndex);
    }

    void OnGUI()
    {
        if (dist <= minDist)
        {
            if (player.GetInventory().Count > 0)
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
