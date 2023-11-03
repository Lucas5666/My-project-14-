using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;
using CaiLu_LegendOfValmosian;

public class ScoreCheck : MonoBehaviour
{

    public int finalScore;

    private Text scoreText;


    private int countDownSecond;

    private float nextTime = 1;


    void Start()
    {
        //设置UI文本的显示
        countDownSecond = 11;
        scoreText = TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").GetComponent<Text>();
        scoreText.text = "CountDown : " + countDownSecond;
        //print(scoreText.text + "start");

    }

    void Update()
    {
        //print(finalScore);

        //print(scoreText.text + "update");


        if (Time.time >= nextTime && countDownSecond > 0)
        {
            //则倒计时减一秒
            countDownSecond--;
            //显示倒计时文本
            scoreText.text = "CountDown : " + countDownSecond;
            nextTime = Time.time + 1;//设置下次修改时间   在当前时间上加一
            if (countDownSecond <= 5)//当时间 小于等于5秒时，变为红色字体
            {
                scoreText.color = Color.red;
            }
        }
        //判断是否在指定时间内 消除了所以的砖块 
        if (finalScore == 68 && countDownSecond > 0)
        {
            //激活胜利面板
            UIMgr.Instance.ShowUI("BreakBrickswinView");
            //调用加血方法 给角色血加满
            Destroy(GameObject.Find("BreakBricksMap"));
            Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").gameObject);
            PlayerStatus.PlayerGO.GetComponent<PlayerStatus>().AddHealth(10);
            if (!MedalRecord.BreakBricksGame)
            {
                PlayerStatus.medalNum++;
                MedalRecord.BreakBricksGame = true;
            }
            //countDownSecond = -1;
            //判断当前关卡是否 已经加过勋章 如果没有才添加勋章
            //if(PlayerPrefs.GetInt("BreakBricksMedal") == 0)
            //{
            //    PlayerPrefs.SetInt("PlayerMedal", PlayerPrefs.GetInt("PlayerMedal") + 1);
            //    PlayerPrefs.SetInt("BreakBricksMedal", 1);
            //}
        }
        //如果时间结束没有完成任务 调出失败面板
        if (countDownSecond <= 0 && finalScore < 68)
        {
            UIMgr.Instance.ShowUI("BreakBricksFailedView");
            Destroy(GameObject.Find("BreakBricksMap"));
            Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").gameObject);
            //countDownSecond = 999999;
        }
    }
}
