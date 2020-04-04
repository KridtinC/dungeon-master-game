using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : ItemController
{
    public float attack;
    public float range;

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (pickup)
        {
            transform.position = player.transform.position;
        }
    }

    public float GetAttack()
    {
        return attack;
    }

    public float GetRange()
    {
        return range;
    }
}
