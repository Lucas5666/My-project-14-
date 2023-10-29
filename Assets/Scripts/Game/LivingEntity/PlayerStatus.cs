using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace CaiLu_LegendOfValmosian
{
    /// <summary>
    /// 主角状态
    /// </summary>
    public class PlayerStatus : CharacterStatus
    {
        private float timer;
        public static GameObject PlayerGO = null;
        public Slider healthBar;
        public int medalNum = 3;
        public Text medalText;



        /// <summary>
        /// 经验
        /// </summary>
        public int Exp;
        /// <summary>
        /// 最大经验
        /// </summary>
        public int MaxExp;

        private void Start()
        {
            this.HP = 10;
            PlayerGO = GameObject.FindWithTag("Player");
            healthBar = TransformHelper.FindChild(UIMgr.canvas, "HealthBar").GetComponent<Slider>();
            medalText = TransformHelper.FindChild(UIMgr.canvas, "MedalCount").GetComponent<Text>();

        }
        private void Update()
        {
            timer = timer + Time.deltaTime;
            healthBar.value = this.HP;
            medalText.text = medalNum.ToString();


        }

        /// <summary>
        /// 收集经验
        /// </summary>
        public void CollectExp()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 升级
        /// </summary>
        public void LevelUp()
        {
            throw new System.NotImplementedException();
        }

        public override void Dead()
        {
            Debug.Log("死了");
        }
        public override void OnDamage(int damageVal)
        {
            base.OnDamage(damageVal);
            print("PlayerStatus OnDamage ");
        }

        private void OnCollisionEnter(Collision collision)
        {


            if (collision.gameObject.tag == "Enemy_1" && !Input.GetKey(KeyCode.Q) && timer > 0.3)
            {
                OnDamage(1);
                //this.transform.Translate(-Vector3.forward * 2);
                timer = 0;

            }


        }

        public  void AddHealth(int i)
        {
            this.HP = ((this.HP += i) <= 10) ? this.HP + i :this.HP = 10;

        }

        //勋章添加方法 勋章是否添加标志 勋章重置方法（开始游戏时重置）

        //血量显示 变化 血量添加方法

        //是否添加射击功能 添加射击功能

        //

    }
}