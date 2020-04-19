using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelRainBullet : BossLevelBullet
{
    public override void Generate() {
        direction = -gameObject.transform.up;
    }
}
