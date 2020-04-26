using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceKeyDoorController : MonoBehaviour
{
    public PlaceKeyItemController[] PlaceKey;
    protected bool check;
    protected bool isDown = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (CheckTrigged())
        {
            isDown = true;
            goDown();
            
        }
        else if(isDown)
        {
            print("eiei");
            goUp();
            isDown = false;
        }

    }

    void goDown()
    {
        
        if (transform.position.y > -1)
        {
            //float YY = transform.position.y;
            //YY = YY - 0.05f;
            //transform.position = new Vector3(transform.position.x, YY, transform.position.z);
            transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
        }

    }

    void goUp()
    {
        while (transform.position.y < 0.459)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            //float YY = transform.position.y;
            //YY = YY + 0.05f;
            //transform.position = new Vector3(transform.position.x, YY, transform.position.z);
        }

    }

    bool CheckTrigged()
    {
        if (PlaceKey.Length < 2)
        {
            check = PlaceKey[0].getIsCorrect();
        }
        else
        {
            for (int i = 0; i < PlaceKey.Length - 1; i++)
            {
                check = PlaceKey[i].getIsCorrect() && PlaceKey[i + 1].getIsCorrect();
            }
            
        }

        return check;
    }
}
