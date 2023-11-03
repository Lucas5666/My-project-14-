using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using CaiLu_LegendOfValmosian;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : CharacterStatus
{

    public NavMeshAgent navMeshAgent;
    public Transform target;
    private float timer;


    //获取敌人的导航网格 将敌人死亡时的方法订阅到敌人死亡事件
    protected  void Start()
    {
        //base.Start();

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

   

}
