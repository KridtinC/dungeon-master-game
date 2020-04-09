using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelCamera : MonoBehaviour
{
    public PlayerController Player;
    public EnemyController Boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Boss.transform.position - Player.transform.position;
        direction.y = 0;

        direction *= Mathf.Max(12, direction.magnitude) / direction.magnitude;

        transform.position = Boss.transform.position - 2*direction;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
