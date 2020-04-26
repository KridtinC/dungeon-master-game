using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialHint : MonoBehaviour
{
    public PlayerController player;
    protected float dist;
    protected float minDist = 2f;
    public string hintText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);

    }

    void OnGUI()
    {
        if (dist <= minDist)
        {
            GUI.TextArea(new Rect(100, 150, 200, 50), hintText);
        }
    }
}
