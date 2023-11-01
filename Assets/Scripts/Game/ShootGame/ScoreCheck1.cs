using System.Collections;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck1 : MonoBehaviour
{

    public int i;
 

    //初始化 
    void Start()
    {
        //failedGamePage.SetActive(false);
        //winPage.SetActive(false);

        //player.GetComponent<LivingEntity>().onDeath += LoadFailedGamePage;
        i = 1;
        this.GetComponent<PlayerController>().HP = (int)MonsterPlatformView_Ctrl.BeforeCharHealth;
        
    }

    void Update()
    {
        //显示血量
        //if (player != null)
        //{
        //    //currenthealth = player.GetComponent<LivingEntity>().health;
        //    //health.text = "Health :" + currenthealth;
        //}
        TransformHelper.FindChild(UIMgr.canvas, "HealthBar").GetComponent<Slider>().value = this.GetComponent<PlayerController>().HP;

        //如果所有的敌人被消灭 调出胜利页面 加血 勋章数量加1 并标记 
        if (GameObject.FindGameObjectWithTag("Spawner") == null && i == 1)
        {
            UIMgr.Instance.ShowUI("ShootingGameWinView");
            PlayerStatus.PlayerGO.GetComponent<PlayerStatus>().AddHealth(10);
            i = 0;
            
        }


    }

  

}
