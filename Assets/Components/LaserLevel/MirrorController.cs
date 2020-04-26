using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    public PlayerController player;
    protected float dist;

    protected float minDist = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= minDist && Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }
    }

    void OnGUI()
    {
        if (dist <= minDist)
        {
            GUI.TextArea(new Rect(300, 50, 200, 100), "Press 'Q' to rotate.");
        }
    }
}
