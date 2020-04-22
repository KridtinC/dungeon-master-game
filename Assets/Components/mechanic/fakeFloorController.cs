using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeFloorController : MonoBehaviour
{
    public PlayerController player;
    protected float dist;
    protected float minDist = 1f;
    protected bool isStep = false;
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if (!isStep)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
            if (dist <= minDist)
            {
                isStep = true;
            }
            else
            {
                isStep = false;
            }

        }
        else
            gameObject.SetActive(false);
        
    }
}
