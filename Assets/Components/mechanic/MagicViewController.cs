using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicViewController : ItemController
{
    public AuraController[] aura;
    private bool isUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (pickup)
        {
            this.GetComponent<Renderer>().enabled = false;
            print(player.GetInventory().Contains(this));
        }
        else
        {
            this.GetComponent<Renderer>().enabled = true;
        }
        if (player.GetInventory().Contains(this)){
            if (Input.GetKeyDown(KeyCode.Q))
            {

                print("HI");
                if (!isUsed)
                {
                    print(isUsed);
                    for (int i = 0; i < aura.Length; i++)
                    {
                        aura[i].toHide();
                    }
                    isUsed = true;
                    player.setUnmove();
                }
                else if (isUsed)
                {
                    for (int i = 0; i < aura.Length; i++)
                    {
                        aura[i].toReveal();
                    }
                    isUsed = false;
                    player.setMove();
                }
                
            }

        }
    }

    void OnGUI()
    {
        if (dist <= minDist && !pickup)
        {
            GUI.TextArea(new Rect(100, 50, 200, 100), text);
        }
        if (!player.getMovable()&&player.GetHP()>0)
        {
            GUI.TextArea(new Rect(300, 300, 200, 50), "Press Q to Move again");
        }
    }
}
