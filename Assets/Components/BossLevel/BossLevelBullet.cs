using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevelBullet : MonoBehaviour
{
    public PlayerController Player;
    public bool active = false;

    protected Vector3 direction;
    protected virtual float getUnitAttack() { return 10; }
    public Vector3 getDirection() { return direction; }

    // Start is called before the first frame update
    void Start()
    {
        Generate(Player.gameObject);
    }

    protected float Bound = 70f;

    // Update is called once per frame
    void Update()
    {
        render();
        if (!active) return;
        transform.position += direction * Time.deltaTime * 20f;
        if (transform.position.x < -Bound || transform.position.x > Bound) {
            Destroy(this.gameObject);
        } else if (transform.position.z < -Bound || transform.position.z > Bound) {
            Destroy(this.gameObject);
        } else if (transform.position.y < -Bound) {
            Destroy(this.gameObject);
        }
    }

    void render() {
        gameObject.SetActive(active);
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if (mesh) mesh.enabled = active;
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
        }
    }

    public virtual void Generate(GameObject target)
    {
        direction = target.gameObject.transform.position - transform.position;
        direction.Normalize();
    }
}
