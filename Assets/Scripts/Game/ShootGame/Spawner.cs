using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Wave[] waves;

    [Header("JUST FOR CHECK ! ! !")]
    [SerializeField] private Wave currentWave;//当前波
    [SerializeField] private int currentIndex;//当前波在数组集合中的【序号、索引 Index】

    public int waitSpawnNum;//这一波还剩下多少敌人没有生成，等于0以后的话，不该再生成新的敌人了
    public int spawnAliveNum;//这一波的敌人还存活了多少个，少于0的话，则应该触发，下一波敌人的逻辑执行
    public float nextSpawnTime;

    private void Start()
    {
        enemyPrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Props , "Enemy");
        waves = new Wave[]
        {
            new Wave(3,2),
            new Wave(6,1),
            new Wave(10,0.5f),
            new Wave(20,0.5f),
        };
        NextWave();
    }

    private void NextWave()
    {
        currentIndex++;
        Debug.Log(string.Format("Current Wave : {0}", currentIndex));

        if(currentIndex - 1 < waves.Length)
        {
            currentWave = waves[currentIndex - 1];//一开始Index = 1，所以currentWave = waves[currentIndex - 1] 数组0的位置
            waitSpawnNum = currentWave.enemyNum;
            spawnAliveNum = currentWave.enemyNum;
        }
    }

    //生成敌人了！
    private void Update()
    {
        if(waitSpawnNum > 0 && Time.time > nextSpawnTime)//间隔事件内，产生敌人
        {
            waitSpawnNum--;//等待生成的敌人 - 1
            GameObject spawnEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            //Debug.Log(enemyPrefab.name);
            spawnEnemy.AddComponent<EnemyInShootingGame>();
            spawnEnemy.transform.SetParent(this.transform);

            //生成新敌人
            //每当生成新的敌人，就要将这个敌人的”阵亡事件处理器“【【订阅】】到事件onDeath上
            spawnEnemy.GetComponent<EnemyInShootingGame>().onDeath += EnemyDeath;//CORE

            nextSpawnTime = Time.time + currentWave.timeBtwSpawn;
        }

        if(currentIndex == waves.Length + 1 && waitSpawnNum == 0 && spawnAliveNum == 0)
        {
            Destroy(this.gameObject);
        }
    }

    //当敌人阵亡时，spawnAliveNum - 1，spawnAliveNum = 0时候，下一波
    //每次有敌人阵亡，我们都会判断，这是不是场上最后一个敌人，最后一个敌人如果阵亡了，那么就开始下一波的进攻
    private void EnemyDeath()
    {
        spawnAliveNum--;

        if(spawnAliveNum <= 0)
        {
            NextWave();
        }
    }
}
