using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace CaiLu_LegendOfValmosian
{
    /// <summary>
    /// 小怪状态
    /// </summary>
    ///

    [RequireComponent(typeof(NavMeshAgent))]
    public class MonsterStatus : CharacterStatus
    {
        /// <summary>
        /// 贡献经验值
        /// </summary>
        public int GiveExp;

        public NavMeshAgent navMeshAgent;
        public Transform target;

        //获取敌人的导航网格 将敌人死亡时的方法订阅到敌人死亡事件
        protected void Start()
        {
            //base.Start();
            this.onDeath += EnemyDeath;
            navMeshAgent = GetComponent<NavMeshAgent>();
            if (GameObject.FindWithTag("Player").transform != null)
            {
                target = PlayerStatus.PlayerGO.transform;
            }

        }

        //重写父类的死亡方法
        private void EnemyDeath()
        {
            Destroy(this.gameObject);
            print("MonsterStatus Dead ");
        }

        //设置敌人的注视方向 以及移动方向 检测玩家是否按下攻击按钮 计时器
        void Update()
        {
            if (this.gameObject.activeInHierarchy && GameObject.FindWithTag("Player") != null)
            {
                this.transform.LookAt(target);
                navMeshAgent.SetDestination(target.position);
            }

        }

        //重写父类的伤害方法

        public override void OnDamage(int damageVal)
        {
            base.OnDamage(damageVal);

            //this.transform.Translate(-UnityEngine.Vector3.forward);
            

            StartCoroutine(ChangeColor(this.gameObject));

            this.transform.Translate(-Vector3.forward);

            print("MonsterStatus OnDamage ");
        }

        //利用协程来使敌人受到伤害时会有红色的闪烁
        private IEnumerator ChangeColor(GameObject col)
        {

            Color newColor = new Color(1, 0, 0,1);
            Color oldColor = new Color(1, 1, 1,1);

            Transform childTransform = transform.Find("Body");
            if(childTransform != null)
            {

                childTransform.GetComponent<MeshRenderer>().material.SetColor("_color", newColor);
                yield return new WaitForSeconds(0.1f);
                //print("染色");
                childTransform.GetComponent<MeshRenderer>().material.SetColor("_color", oldColor);
                //col.transform.Translate(-Vector3.forward);
            }
            Transform childTransform2 = transform.Find("group1");
            if (childTransform2 != null)
            {
                //print("zhaodaole");
                Transform childTransform3 = childTransform2.Find("body");
                //print("zhaodaole222");
                childTransform3.GetComponent<SkinnedMeshRenderer>().material.color = newColor;
                yield return new WaitForSeconds(0.2f);
                //print("zhaodaole333");
                childTransform3.GetComponent<SkinnedMeshRenderer>().material.color = oldColor;
                //col.transform.Translate(-Vector3.forward);
            }

        }

    }
}
