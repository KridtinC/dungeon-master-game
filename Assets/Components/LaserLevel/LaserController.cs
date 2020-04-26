using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    private LineRenderer lr;
    public Vector3 initDirection;
    RaycastHit hit;
    private int mirrorChainNumber = 5;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    void LaserLogic(int prevPosition, int currPosition, int nextPosition, Vector3 currentLaserDirection, int positionCount)
    {
        if (Physics.Raycast(lr.GetPosition(prevPosition), currentLaserDirection, out hit))
        {
            if (hit.collider.name.Contains("Mirror"))
            {
                lr.SetPosition(currPosition, hit.point);
                lr.positionCount = positionCount + 1;
                Vector3 nextLaserDirection = checkDirection(hit.collider.gameObject, (lr.GetPosition(currPosition) - lr.GetPosition(prevPosition)).normalized);
                if (nextLaserDirection != Vector3.zero)
                    lr.SetPosition(nextPosition, nextLaserDirection * 5000);
                else
                    lr.SetPosition(nextPosition, hit.point);
                if(positionCount < mirrorChainNumber)
                    LaserLogic(prevPosition + 1, currPosition + 1, nextPosition + 1, nextLaserDirection, positionCount + 1);
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
                    lr.SetPosition(currPosition, hit.point);
                }
            }
            else
            {
                lr.positionCount = positionCount;
                lr.SetPosition(currPosition, hit.point);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        LaserLogic(0, 1, 2, initDirection, 2);
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