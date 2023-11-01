using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;
using CaiLu_LegendOfValmosian;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyInShootingGame : CharacterStatus
{
    private NavMeshAgent navMeshAgent;
    private Transform target;

    [SerializeField] private float updateRate = 0.5f;

    private bool hasTarget;

    public override void OnDamage(int damageVal)
    {
        ////写所有受到伤害是共性的表现 HP减少！
        ////受击者 有防御能力
        //damageVal = damageVal - Defence;
        //if (damageVal > 0)
        //    HP -= damageVal;
        ////if (HP <= 0) Dead();
        ////子类可以再加上个性的表现
        ///
        base.OnDamage(damageVal);
    }


    protected  void Start()
    {
        //base.Start();
        MaxHP = 2;
        HP = MaxHP;
        this.onDeath += Death;

        //获取导航代理
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            hasTarget = true;
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //将TargetDeath方法订阅到死亡事件
            target.GetComponent<CharacterStatus>().onDeath += TargetDeath;
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

    private void Death()
    {
        Destroy(this.gameObject);
    }

  

}
