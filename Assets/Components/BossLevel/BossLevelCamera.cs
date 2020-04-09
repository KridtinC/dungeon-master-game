using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelCamera : MonoBehaviour
{
    public PlayerController Player;
    public BossController Boss;

    private Vector3 position;

    void Start() {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Boss.OnTop()) {
            position = Player.transform.position;
        }
        Vector3 direction = Boss.transform.position - position;
        direction.y = 0;

        float length = Mathf.Clamp(direction.magnitude, 12, 30);
        float singleStep = 3 * Time.deltaTime;
        direction = Vector3.RotateTowards(transform.forward, direction, singleStep, 0.0f);

        Vector3 newPosition = Boss.transform.position - 2f * direction * length;
        newPosition.y = Player.transform.position.y + 3;

        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
