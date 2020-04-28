using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHP() <= 0)
        {
            player.setUnmove();
            //RestartAfterTime(3f);
            Restart();
        }
        if (player.transform.position.y < -10)
        {
            Respawn();
        }
        
    }

    void OnGUI()
    {
        if (player.GetHP() <= 0)
        {

            GUI.TextArea(new Rect(100, 50, 200, 100), "YOU DIED");
        }
    }

    void Respawn()
    {
        player.gameObject.transform.position = new Vector3(0,1,0);
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Restart();
    }
}
