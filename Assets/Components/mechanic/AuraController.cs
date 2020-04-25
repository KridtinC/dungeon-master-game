using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraController : MonoBehaviour
{
    protected bool isOn = false;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            print("on");
            this.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            print("off");
            this.GetComponent<Renderer>().enabled = false;
        }
    }

    public void toHide()
    {
        isOn = true;
    }

    public void toReveal()
    {
        isOn = false;

    }
}
