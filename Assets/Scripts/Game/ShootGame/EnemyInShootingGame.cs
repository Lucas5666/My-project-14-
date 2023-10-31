using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyInShootingGame : LivingEntity
{
    private NavMeshAgent navMeshAgent;
    private Transform target;

    [SerializeField] private float updateRate = 2.0f;

    private bool hasTarget;

    
    
    protected override void Start()
    {
        base.Start();
        //获取导航代理
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //将TargetDeath方法订阅到死亡事件
            target.GetComponent<LivingEntity>().onDeath += TargetDeath;
            //在开始执行协程函数
            StartCoroutine(UpdatePath());
        }

        
    }

    private void TargetDeath()
    {
        //死亡岁 标记hasTarget
        //Debug.Log("hasTarget is False");
        hasTarget = false;
    }

    //寻路 朝着角色移动 
    IEnumerator UpdatePath()
    {
        while (hasTarget)
        {
            if (isDead == false)
            {
                Vector3 preTargetPos = new Vector3(target.position.x, 0, target.position.z);//玩家位置信息
                navMeshAgent.SetDestination(preTargetPos);
            }

            yield return new WaitForSeconds(updateRate);
        }
    }

  

}
