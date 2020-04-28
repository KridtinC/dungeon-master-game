using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedFakeFloor : MonoBehaviour
{
    public PlayerController player;
    protected bool isStep = false;
    protected Vector3 startPosition;
    public LevelController level;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        if (isStep)
          StartCoroutine(ExecuteAfterTime(2f));

        if (level.getRespawn())
        {
            isStep = false;
            moveUp();
            level.setRespawn();
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        transform.Translate(Vector3.down * Time.deltaTime * 3, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            isStep = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        isStep = false;
    }

    public void moveUp()
    {
        while (gameObject.transform.position.y < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10, Space.World);
        }

    }
}
