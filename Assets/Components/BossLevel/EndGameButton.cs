using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    protected bool isFinish;
    protected bool isActive;
    public bool IsFinish() { return isFinish; }
    public void Done() { isFinish = true; }
    public void Activate() { isActive = true; }

    void Start()
    {
        isActive = false;
        isFinish = false; 
    }

    void Update() {
        GetComponent<MeshRenderer>().enabled = isActive;
    }

    void OnCollisionEnter(Collision collision) {
        if (!isActive) return;
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player) {
            isFinish = true;
        }
    }
}
