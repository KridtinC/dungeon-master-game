using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossLevelController : MonoBehaviour
{
    public PlayerController player;
    public BossController boss;
    public EndGameButton button;

    protected void reload() {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    void Update() {
        if (Input.GetKey(KeyCode.P)) {
            player.RefillHP();
        }
        if (boss != null && player != null) {
            if (player.GetHP() <= 0) {
                reload();
            }
            if (player.transform.position.y < -10) {
                reload();
            }
        }
        if (boss == null) {
            // button.Done();
            button.Activate();
        }
    }

    public Texture2D fadeTexture;
    protected float fadeDir = 1f;
    protected float fadeSpeed = 0.15f;
    protected float alpha = 0;
    protected int drawDepth = 2000;

    void OnGUI(){
        if (!button.IsFinish()) return;

        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color color = new Color (255, 255, 255, alpha);
        Texture2D texture = new Texture2D(1, 1);
        texture.SetPixel(0,0,color);
        texture.Apply();
        GUI.skin.box.normal.background = texture;
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none);
    }

}
