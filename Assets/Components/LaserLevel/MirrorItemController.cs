﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorItemController : ItemController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        if (pickup)
        {
            gameObject.SetActive(false);
        }
    }
}
