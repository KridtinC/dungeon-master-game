using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
    }

    public void activate()
    {
        isOpen = true;
        gameObject.SetActive(!isOpen);
    }
    public bool GetIsOpen()
    {
        return isOpen;
    }

    public Color GetDoorColor()
    {
        return GetComponent<Renderer>().material.GetColor("_Color");
    }
}
