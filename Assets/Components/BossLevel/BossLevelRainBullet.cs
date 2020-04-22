using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelRainBullet : BossLevelBullet
{

    protected override float getUnitAttack() { return 5; } 

    public override void Generate(GameObject target) {
        if (target != null) {
            direction = target.gameObject.transform.position - transform.position;
            direction.Normalize();

            gameObject.transform.rotation = 
                Quaternion.LookRotation(transform.right, direction);
        } else {
            direction = -gameObject.transform.up;
        }
    }
}
