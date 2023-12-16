using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaiLu_LegendOfValmosian;
//using System;

[RequireComponent(typeof(Rigidbody))] 
public class PlayerBullet : MonoBehaviour
{
    //伤害量
    public int _damageAmount = 1;
    //private Vector3 targetPos;

    //private void Awake()
    //{
    //    targetPos = this.transform.TransformPoint(0, 0, 50);
    //}



    //private void Update()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * 50);

    //    if(Vector3.Distance(transform.position,targetPos) < 0)
    //    {
    //        GameObjectPool.Instance.CollectObject(gameObject);
    //    }
    //}

    private void Start()
    {
       GameObjectPool.Instance.CollectObject(gameObject,1);
    }



    //碰撞时造成伤害
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_1"  )
        {
            collision.gameObject.GetComponent<CharacterStatus>().OnDamage(_damageAmount);
            collision.transform.Translate(-Vector3.forward * 2);
            
        }

    }
}
