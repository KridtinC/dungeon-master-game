using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepController : EnemyController
{
    

    // Start is called before the first frame update
    protected override void Start()
    {
        isFollow = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Vector3.Distance(player.transform.position, transform.position)> 6)
        {
            isFollow = false;
        }
        else
        {
            isFollow = true;
        }
    }
}
