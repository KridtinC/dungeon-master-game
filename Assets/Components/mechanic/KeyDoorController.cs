using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorController : MonoBehaviour
{
    public PlaceKeyItemController[] PlaceKey;
    protected bool check;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (CheckTrigged())
        {
            if (transform.position.y > -1)
            {
                float YY = transform.position.y;
                YY = YY - 0.05f;
                transform.position = new Vector3(transform.position.x, YY, transform.position.z);
            }

        }

    }

    bool CheckTrigged()
    {
        if (PlaceKey.Length < 2)
        {
            return PlaceKey[0].getIsCorrect();
        }
        else
        {
            for (int i = 0; i < PlaceKey.Length - 1; i++)
            {
                check = PlaceKey[i].getIsCorrect() && PlaceKey[i + 1].getIsCorrect();
            }
            return check;
        }
    }
}
