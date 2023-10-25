using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        if (GameObject.FindWithTag("Player").transform != null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {
        CheckDistance();
    }
    private int spawnedCount;
    public int maxCount = 2;

    public int maxDelay = 2;
    public GameObject enemy;

    //public GameObject player;

    public int Dis = 6;
    public int speed = 2;
    public GameObject[] GeneratePoint = new GameObject[5];
    private int GeneratePointIndex;

    public void CheckDistance()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(this.transform.position, target.transform.position);
            if (distance <= Dis)
            {
                GenerateEnemy();
            }

        }

    }

    public void GenerateEnemy()
    {
        if (spawnedCount < maxCount)
        {
            spawnedCount++;
            float delay = Random.Range(0, maxDelay);
            Invoke("CreateEnemy", delay);
        }
    }

    private void CreateEnemy()
    {
        GeneratePointIndex = Random.Range(0, GeneratePoint.Length);
        GameObject enemyGo = Instantiate(enemy, GeneratePoint[GeneratePointIndex].transform.position, Quaternion.identity);
        enemyGo.AddComponent<Enemy>();
        enemyGo.AddComponent<NavMeshAgent>();
        enemyGo.GetComponent<NavMeshAgent>().SetDestination(target.position);
    }


}
