using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    private LineRenderer lr;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(lr.GetPosition(0), Vector3.right, out hit))
        {
            
            if(hit.collider.name.Contains("Mirror1"))
            {
                RaycastHit hit2;
                lr.SetPosition(1, new Vector3(0, 1, -21));
                lr.positionCount = 3;
                Vector3 direction;

                if (hit.collider.gameObject.transform.eulerAngles.y.ToString().Equals("45") || hit.collider.gameObject.transform.eulerAngles.y.ToString().Equals("225"))
                {
                    lr.SetPosition(2, new Vector3(0, 1, -42));
                    direction = Vector3.back;
                }
                else
                {
                    lr.SetPosition(2, new Vector3(0, 1, 0));
                    direction = Vector3.forward;
                }

                if(Physics.Raycast(lr.GetPosition(1), direction, out hit2)){
                    if (hit2.collider.name.Contains("Mirror2"))
                    {
                        print(hit2.collider);
                    }
                    else
                    {
                        lr.positionCount = 3;
                        lr.SetPosition(2, hit2.point);
                    }
                }
                
                
            }
            else
            {
                lr.positionCount = 2;
                lr.SetPosition(1, hit.point);
            }
        }
    }
}