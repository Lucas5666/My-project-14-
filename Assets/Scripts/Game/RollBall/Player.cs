using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    private Rigidbody rd;

    private int score = 0;

    private Text scoreText;

    private int speed = 2;

    private GameObject winPanel;

    private GameObject failedPanel;

    public static int countDownSecond = 17;

    private float nextTime = 1;


    void Start()
    {
        //设置显示UI文本
        scoreText = TransformHelper.FindChild(GameObject.FindWithTag("Canvas").transform, "RollBallScoreView").GetComponent<Text>();
        scoreText.text = "CountDown : " + countDownSecond;
        //Time.timeScale = 1;

    }

    void Update()
    {
        if (Time.time >= nextTime && countDownSecond > 0)
        {
            //倒计时减一秒
            countDownSecond--;
            //显示倒计时文本
            scoreText.text = "CountDown : " + countDownSecond;
            nextTime = Time.time + 1;//设置下次修改时间   在当前时间上加一
            if (countDownSecond <= 5)//当时间 小于等于5秒时，变为红色字体
            {
                scoreText.color = Color.red;
            }
        }

        if (score == 12 && countDownSecond > 0)
        {
            //调出胜利面板
            //winPanel.SetActive(true);
            UIMgr.Instance.ShowUI("RollBallWinPanelView");
            countDownSecond = 9999999;
            //调用加血方法 给角色血加满
            ////AddHealth.Add();
            //判断当前关卡是否 已经加过勋章 如果没有才添加勋章
            //if (PlayerPrefs.GetInt("RollBallMedal") == 0)
            //{
            //    PlayerPrefs.SetInt("PlayerMedal", PlayerPrefs.GetInt("PlayerMedal") + 1);
            //    PlayerPrefs.SetInt("RollBallMedal", 1);

            //}

        }
        //失败 调出失败面板
        if (score <= 12 && countDownSecond <= 0)
        {
            //failedPanel.SetActive(true);
            UIMgr.Instance.ShowUI("RollBallFailedPanelView");
            countDownSecond = 9999999;

        }
    }

    //判断是否接触 接触销毁食物 并分数加一
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score++;
        }

    }
    
}
