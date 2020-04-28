using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairController : MonoBehaviour
{
    public PlayerController player;
    private float dist;

    protected float minDist = 4f;

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= minDist && Input.GetKey(KeyCode.Space))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4); //Next level
        }

    }

    void OnGUI()
    {
        if (dist <= minDist)
        {
            GUI.TextArea(new Rect(100, 50, 200, 100), "Press Spacebar to move to next level");
        }
    }
}
