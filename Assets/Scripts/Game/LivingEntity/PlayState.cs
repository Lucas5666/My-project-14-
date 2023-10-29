using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayState : LivingEntity
{

    //public Player_Controler inputControl;
    public float _damageAmount;
    public float status;
    private float timer;
    public GameObject healthBar;
    public Text medalText;
    public float sp;

    public int medalNum;

    private void Awake()
    {
        //inputControl = new Player_Controler();

    }

    private void OnEnable()
    {
       // inputControl.Enable();
    }

    private void OnDisable()
    {
       // inputControl.Disable();
    }


    protected override void Start()
    {
        base.Start();
    }

    //显示UI生命值 勋章 检测是否按下Fight按钮 计时器
    void Update()
    {
        healthBar.GetComponent<Slider>().value = health;

        medalText.text = medalNum.ToString();

       // status = inputControl.Player.Fight.ReadValue<float>();

       
        timer = timer + Time.deltaTime;

        
    }

    //碰撞到敌人时 受到伤害 死亡时回到菜单
    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.tag == "Enemy_1" && status == 0 && timer > 0.3)
        {
            TakenDamage(_damageAmount);
            this.transform.Translate(-Vector3.forward * 2);
            timer = 0;

        }

        if (health <= 0)
        {
            Debug.Log("死了");
        }



    }

    //勋章添加方法 勋章是否添加标志 勋章重置方法（开始游戏时重置）

    //血量显示 变化 血量添加方法

    //是否添加射击功能 添加射击功能

    //


}
