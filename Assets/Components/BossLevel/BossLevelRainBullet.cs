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
                Quaternion.LookRotation(
                    Quaternion.AngleAxis(90, transform.up) * direction,
                    Vector3.up
                );
        } else {
            direction = -gameObject.transform.up;
        }
    }
}
