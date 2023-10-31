using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCheck1 : MonoBehaviour
{
    // Start is called before the first frame update

    public Text health;
    private float currenthealth;
    public GameObject player;

    public GameObject failedGamePage;
    public GameObject winPage;

    //初始化 
    void Start()
    {
        failedGamePage.SetActive(false);
        winPage.SetActive(false);

        player.GetComponent<LivingEntity>().onDeath += LoadFailedGamePage; 
    }

    void Update()
    {
        //显示血量
        if(player != null)
        {
            currenthealth = player.GetComponent<LivingEntity>().health;
            health.text = "Health :" + currenthealth;
        }

        //如果所有的敌人被消灭 调出胜利页面 加血 勋章数量加1 并标记 
        if (GameObject.FindGameObjectWithTag("Spawner") == null)
        {
            winPage.SetActive(true);
            //AddHealth.Add();

            //if (PlayerPrefs.GetInt("ShootingMedal") == 0)
            //{
            //    PlayerPrefs.SetInt("PlayerMedal", PlayerPrefs.GetInt("PlayerMedal") + 1);
            //    PlayerPrefs.SetInt("ShootingMedal", 1);
            //}
        }
      

    }

    //已经订阅到死亡事件 死亡时执行这个方法 调出失败页面
    public void LoadFailedGamePage()
    {
        failedGamePage.SetActive(true);
        health.color = new Vector4(0, 0, 0, 0);
    }

}
