using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDoorController : MonoBehaviour
{
    public triggerController[] trigger; 
    protected bool check;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (CheckTrigged())
        {
            if(transform.position.y > -1)
            {
                float YY = transform.position.y;
                YY = YY - 0.05f;
                transform.position = new Vector3(transform.position.x, YY, transform.position.z);
            }
            
        }
        
    }

    bool CheckTrigged()
    {
        if (trigger.Length < 2)
        {
            return trigger[0].getIsTrigged();
        }
        else
        {
            for (int i = 0; i < trigger.Length - 1; i++)
            {
                check = trigger[i].getIsTrigged() && trigger[i + 1].getIsTrigged();
            }
            return check;
        }
    }
}
