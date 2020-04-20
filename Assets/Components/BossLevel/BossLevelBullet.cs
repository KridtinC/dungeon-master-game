using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelBullet : MonoBehaviour
{
    public PlayerController Player;
    public bool active = false;

    protected Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<MeshRenderer>().enabled = active;
        if (!active) return;
        transform.position += direction * Time.deltaTime * 20f;
        if (transform.position.y < Player.gameObject.transform.position.y - 5) {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (!active) return;
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            player.OnAttack(10);
            Destroy(this.gameObject);
        }
    }

    public virtual void Generate()
    {
        direction = Player.gameObject.transform.position - transform.position;
        direction.Normalize();
    }
}
