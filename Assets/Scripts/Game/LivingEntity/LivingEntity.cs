using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

//生命实体的父类
public class LivingEntity : MonoBehaviour,IDamageable
{
    public float maxHealth;
    public float health;
    protected bool isDead;

    //声明事件 
    public event Action onDeath;

    
    //初始化血量
    protected virtual void Start()
    {
        health = maxHealth;
    }

    //死亡时标记 并摧毁 动画执行死亡事件
    protected void Die()
    {
        isDead = true;
        Destroy(gameObject);


        if (onDeath != null)
            onDeath();
    }

    //造成伤害 生命值小于等于0时 执行死亡方法
    public void TakenDamage(float _damageAmount)
    {
        health -= _damageAmount;
        if(health <= 0 && isDead == false)
        {
            Die();
        }
    }
}
