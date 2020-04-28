using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_1 : MonoBehaviour
{
    public PlayerController player;
    public GameObject[] objects;
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
        SpawnRandom();
    }

    public void SpawnRandom()
    {
        if (dist <= minDist)
        {
            Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)]);
            StartCoroutine(ExecuteAfterTime(5));
        }
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }
}
