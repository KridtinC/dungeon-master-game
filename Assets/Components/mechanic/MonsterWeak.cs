using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterWeak : EnemyController
{
    protected bool isFollow = false;
    protected float dist;
    protected float maxDist = 10f;
    // Start is called before the first frame update
    protected override void Start()
    {
        isFollow = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (isFollow)
        {
            base.Update();
        }
        if (Vector3.Distance(player.transform.position, transform.position) > 10)
        {
            isFollow = false;
        }
        else
        {
            isFollow = true;
        }

    }
}
