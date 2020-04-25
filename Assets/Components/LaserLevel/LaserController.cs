using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    private LineRenderer lr;
    public Vector3 initDirection;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(lr.GetPosition(0), initDirection, out hit))
        {
            if (hit.collider.name.Contains("Mirror"))
            {
                lr.SetPosition(1, hit.point);
                lr.positionCount = 3;
                Vector3 laserDirectionNext = checkDirection(hit.collider.gameObject, (lr.GetPosition(1) - lr.GetPosition(0)).normalized);
                if (laserDirectionNext != Vector3.zero)
                    lr.SetPosition(2, laserDirectionNext * 5000);
                else
                    lr.SetPosition(2, hit.point);


                if (Physics.Raycast(lr.GetPosition(1), laserDirectionNext, out hit)){

                    if (hit.collider.name.Contains("Mirror"))
                    {
                        lr.SetPosition(2, hit.point);
                        lr.positionCount = 4;
                        Vector3 laserDirectionNext2 = checkDirection(hit.collider.gameObject, (lr.GetPosition(2) - lr.GetPosition(1)).normalized);
                        if (laserDirectionNext2 != Vector3.zero)
                            lr.SetPosition(3, laserDirectionNext2 * 5000);
                        else
                            lr.SetPosition(3, hit.point);


                        if (Physics.Raycast(lr.GetPosition(2), laserDirectionNext2, out hit))
                        {

                            if (hit.collider.name.Contains("Mirror"))
                            {
                                lr.SetPosition(3, hit.point);
                                lr.positionCount = 5;
                                Vector3 laserDirectionNext3 = checkDirection(hit.collider.gameObject, (lr.GetPosition(3) - lr.GetPosition(2)).normalized);
                                if (laserDirectionNext3 != Vector3.zero)
                                    lr.SetPosition(4, laserDirectionNext3 * 5000);
                                else
                                    lr.SetPosition(4, hit.point);


                                if (Physics.Raycast(lr.GetPosition(3), laserDirectionNext3, out hit))
                                {
                                    if (hit.collider.name.Contains("Door"))
                                    {
                                        DoorController door = hit.collider.gameObject.GetComponent<DoorController>();
                                        if (door.GetDoorColor() == GetComponent<Renderer>().material.GetColor("_Color"))
                                        {
                                            door.activate();
                                        }
                                        else
                                        {
                                            lr.SetPosition(4, hit.point);
                                        }
                                    }
                                    else
                                    {
                                        lr.positionCount = 5;
                                        lr.SetPosition(4, hit.point);
                                    }
                                }
                            }
                            else if (hit.collider.name.Contains("Door"))
                            {
                                DoorController door = hit.collider.gameObject.GetComponent<DoorController>();
                                if (door.GetDoorColor() == GetComponent<Renderer>().material.GetColor("_Color"))
                                {
                                    door.activate();
                                }
                                else
                                {
                                    lr.SetPosition(3, hit.point);
                                }
                            }
                            else
                            {
                                lr.positionCount = 4;
                                lr.SetPosition(3, hit.point);
                            }
                        }
                    }
                    else if (hit.collider.name.Contains("Door"))
                    {
                        DoorController door = hit.collider.gameObject.GetComponent<DoorController>();
                        if (door.GetDoorColor() == GetComponent<Renderer>().material.GetColor("_Color"))
                        {
                            door.activate();
                        }
                        else
                        {
                            lr.SetPosition(2, hit.point);
                        }
                    }
                    else
                    {
                        lr.positionCount = 3;
                        lr.SetPosition(2, hit.point);
                    }
                }

            }
            else if (hit.collider.name.Contains("Door"))
            {
                DoorController door = hit.collider.gameObject.GetComponent<DoorController>();
                if (door.GetDoorColor() == GetComponent<Renderer>().material.GetColor("_Color"))
                {
                    door.activate();
                }
                else
                {
                    lr.SetPosition(1, hit.point);
                }
            }
            else
            {
                lr.positionCount = 2;
                lr.SetPosition(1, hit.point);
            }
        }
    }

    Vector3 checkDirection(GameObject gameObj, Vector3 laserDirection)
    {
        string mirrorAngle = gameObj.transform.eulerAngles.y.ToString();
        if (laserDirection == Vector3.forward)
        {
            if (mirrorAngle.Equals("135"))
                return Vector3.right;
            if (mirrorAngle.Equals("225"))
                return Vector3.left;
        }
        else if(laserDirection == Vector3.back)
        {
            if (mirrorAngle.Equals("45"))
                return Vector3.right;
            if (mirrorAngle.Equals("315"))
                return Vector3.left;
        }
        else if(laserDirection == Vector3.right)
        {
            if (mirrorAngle.Equals("225"))
                return Vector3.back;
            if (mirrorAngle.Equals("315"))
                return Vector3.forward;
        }
        else if (laserDirection == Vector3.left)
        {
            if (mirrorAngle.Equals("45"))
                return Vector3.forward;
            if (mirrorAngle.Equals("135"))
                return Vector3.back;
        }
        return Vector3.zero;
    }
}