using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelBullet : MonoBehaviour
{
    public PlayerController Player;
    public bool active = false;

    protected Vector3 direction;
    protected virtual float getUnitAttack() { return 10; }

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
            player.OnAttack(this.getUnitAttack());
            Destroy(this.gameObject);
        }
        EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy) {
            enemy.OnAttack(this.getUnitAttack());
            if (enemy.GetHP() <= 0) {
                Destroy(enemy.gameObject);
            }
        }
    }

    public virtual void Generate()
    {
        direction = Player.gameObject.transform.position - transform.position;
        direction.Normalize();
    }
}
