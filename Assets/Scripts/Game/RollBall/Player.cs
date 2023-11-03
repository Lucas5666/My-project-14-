using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CaiLu_LegendOfValmosian;
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
            UIMgr.Instance.ShowUI("RollBallWinPanelView");
            Destroy(GameObject.Find("RollBallMap"));
            Destroy(TransformHelper.FindChild(UIMgr.canvas, "RollBallScoreView").gameObject);
            PlayerStatus.PlayerGO.GetComponent<PlayerStatus>().AddHealth(10);
            if (!MedalRecord.BollBAllGame)
            {
                PlayerStatus.medalNum++;
                MedalRecord.BollBAllGame = true;
            }
            countDownSecond = -1;
            

        }
        //失败 调出失败面板
        if (score < 12 && countDownSecond <= 0)
        {
            //failedPanel.SetActive(true);
            UIMgr.Instance.ShowUI("RollBallFailedPanelView");
            Destroy(GameObject.Find("RollBallMap"));
            Destroy(TransformHelper.FindChild(UIMgr.canvas, "RollBallScoreView").gameObject);
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
