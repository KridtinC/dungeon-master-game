using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelRainBullet : BossLevelBullet
{

    protected override float getUnitAttack() { return 5; } 

    public override void Generate() {
        direction = -gameObject.transform.up;
    }
}
