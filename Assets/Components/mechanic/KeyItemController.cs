using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemController : ItemController
{
    private bool isCorrectlyUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void setIsCorrectlyUsed(bool i)
    {
        isCorrectlyUsed = i;
    }
}
