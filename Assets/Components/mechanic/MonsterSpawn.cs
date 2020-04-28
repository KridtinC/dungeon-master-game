using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    //public PlayerController player;
    public MonsterWeak fe;
    public int maxSpawn = 3;
    private MonsterWeak[] enemy;
    private int deadCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemy = new MonsterWeak[maxSpawn];
        //enemy[0] = fe;
        for (int i = 0; i < maxSpawn; ++i)
        {
            if (enemy[i] == null || enemy[i].gameObject == null)
            {
                MonsterWeak newEnemy = Instantiate(fe);
                newEnemy.gameObject.SetActive(true);
                newEnemy.transform.position = new Vector3(this.transform.position.x + Random.Range(-1f, 1f), 1, this.transform.position.z + Random.Range(-1f, 1f));

                enemy[i] = newEnemy;
            }
        }
        fe.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(ExecuteAfterTime(3f));
        //updateEnemy();
        CheckEnemyDead();
        if (deadCount >= maxSpawn)
        {
            print(deadCount);
            deadCount = 0;
            StartCoroutine(ExecuteAfterTime(15f));

        }
    }

    //void SpawnEnemy()
    //{
    //    EnemyController e = Instantiate(fe);

    //    e.gameObject.transform.position = new Vector3(this.transform.position.x + Random.Range(-1f, 1f), 0, this.transform.position.z + Random.Range(-1f, 1f));
    //    e.gameObject.SetActive(true);
    //    enemy[enemy.Length-1] = e;
    //}
    void updateEnemy()
    {
        for (int i = 0; i < maxSpawn; ++i)
        {
            if (enemy[i] == null || enemy[i].gameObject == null)
            {
                MonsterWeak newEnemy = Instantiate(fe);
                newEnemy.gameObject.SetActive(true);
                newEnemy.transform.position = new Vector3(this.transform.position.x + Random.Range(-1f, 1f), 1, this.transform.position.z + Random.Range(-1f, 1f));

                enemy[i] = newEnemy;
                //break;
            }
            else if (enemy[i].GetHP() <= 0)
            {
                deadCount++;
                print(deadCount);
                Destroy(enemy[i].gameObject);
                enemy[i] = null;
                //break;
            }
        }
    }

    void CheckEnemyDead()
    {
        for (int i = 0; i < enemy.Length; ++i)
        {
            if (enemy[i] != null && enemy[i].gameObject != null && enemy[i].GetHP() <= 0)
            {
                deadCount++;
                print(deadCount);
                Destroy(enemy[i].gameObject);
                enemy[i] = null;
                //break;
            }
        }
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        updateEnemy();
        
    }
}
