using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{

    public NavMeshAgent navMeshAgent;
    public Transform target;
    public float status;

    public float _damageAmount;

    private float timer;


    //获取敌人的导航网格 将敌人死亡时的方法订阅到敌人死亡事件
    protected override void Start()
    {
        base.Start();

        navMeshAgent = GetComponent<NavMeshAgent>();
        if (GameObject.FindWithTag("Player").transform != null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }

        this.onDeath += EnemyDeath;
    }

    private void EnemyDeath()
    {
        //print("Die!!!");
    }

    //设置敌人的注视方向 以及移动方向 检测玩家是否按下攻击按钮 计时器
    void Update()
    {
        if (this.gameObject.activeInHierarchy && GameObject.FindWithTag("Player") != null)
        {
            this.transform.LookAt(target);
            navMeshAgent.SetDestination(target.position);
        }

        

        timer = timer + Time.deltaTime;

    }

    ////检测是否被玩家攻击所击中 击中扣血 并往后击退 计时器归零
    //private void OnCollisionEnter(Collision collision)
    //{
        

    //    if (collision.gameObject.tag == "Player" && status == 1 && timer > 0.3)
    //    {
    //        TakenDamage(_damageAmount);
    //        this.transform.Translate(-Vector3.forward * 2);
    //        timer = 0;
    //    }

    //}

}
