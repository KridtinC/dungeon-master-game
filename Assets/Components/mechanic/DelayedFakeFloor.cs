using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFakeFloor : MonoBehaviour
{
    public PlayerController player;
    protected bool isStep = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isStep)
          StartCoroutine(ExecuteAfterTime(2f));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isStep = true;
        }
    }
}
