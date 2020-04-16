using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeItemController : ItemController
{
    protected override void Update()
    {
        base.Update();
        if (pickup)
        {
            gameObject.SetActive(false);
        }
    }
}
