using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController : MonoBehaviour
{
    public PlayerController player;
    protected float dist;
    protected string text = "E";
    protected bool isTrigged = false;
    protected float minDist = 1.5f;
    public bool isNotRender;


    // Start is called before the first frame update
    void Start()
    {
        if (isNotRender)
        {
            this.GetComponent<Renderer>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //dist = Vector3.Distance(player.transform.position, transform.position);
        if (!isTrigged)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= minDist)
            {
                if (Input.GetKey(KeyCode.E))
                    isTrigged = true;

            }
            else
            {
                isTrigged = false;
            }

        }
        else
        {
            //dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= minDist)
            {

            }
        }

    }

    void OnGUI()
    {
        if (dist <= minDist && !isTrigged)
        {
                GUI.TextArea(new Rect(100, 50, 200, 100), text);
        }
    }
    
    public bool getIsTrigged()
    {
        return isTrigged;
    }
}
