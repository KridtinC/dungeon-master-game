using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public PlayerController player;
    protected bool isRespawn;
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
            StartCoroutine(RestartAfterTime(3f));
            //Restart();
        }
        if (player.transform.position.y < -10)
        {
            isRespawn = true;
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
        player.gameObject.transform.position = new Vector3(15f,1,65.08f);
    }

    void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }

    public void setRespawn()
    {
        isRespawn = false;
    }

    public bool getRespawn()
    {
        return isRespawn;
    }

    IEnumerator RestartAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        Restart();
    }
}
