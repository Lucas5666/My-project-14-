using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{

    private Animator an;
    [SerializeField]
    private Rigidbody v;
    void Start()
    {
        //获取anmater组件
        an = GetComponent<Animator>();
    }

    void Update()
    {
        v = GetComponent<Rigidbody>();
        //将游戏对象的速度赋值给animator的参数
        if(v.velocity.magnitude < 7)
        {
            an.SetFloat("Speed", v.velocity.magnitude);
        }
        else
        {
            an.SetFloat("Speed", 7);
        }
    }
}
