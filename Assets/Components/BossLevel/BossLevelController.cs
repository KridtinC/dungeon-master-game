using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelController : MonoBehaviour
{
    public PlayerController player;
    public BossController boss;

    protected void reload() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    void Update() {
        if (boss != null && player != null) {
            if (player.GetHP() <= 0) {
                reload();
            }
            if (player.transform.position.y < -10) {
                reload();
            }
        }
    }
}
