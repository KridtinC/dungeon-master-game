using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHudController : MonoBehaviour
{
    public Slider healthBar;
    public EnemyController enemy;
    public GameObject cameraObj;

    public bool onPlayerHud = false;
    public Vector3 offset = new Vector3(0, 1, 0);
    private bool active = true;

    // Update is called once per frame
    void Update()
    {
        if (enemy.GetHP() == 0) {
            active = false;
            Destroy(gameObject);
        }

        healthBar.value = enemy.GetHP();
        if (onPlayerHud) {
            return;
        }

        if (active)
        {
            transform.position = enemy.transform.position + offset;
            transform.rotation = cameraObj.transform.rotation;
        }
    }
}
