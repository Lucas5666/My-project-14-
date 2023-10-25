using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using Cinemachine;

public class StartMenu_View_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();
        //foreach (var kvp in view)
        //{
        //    Debug.Log(kvp.Key);
        //}
    }
    void Start()
    {
        //Debug.Log("111");
        this.AddButtonListener("Button/Play", OnClickPlay);
        this.AddButtonListener("Button/Setting", OnClickSetting);
        this.AddButtonListener("Button/Exit", OnClickExit);
        //Debug.Log("222");

    }

    void OnClickPlay()
    {
        Debug.Log("Play被按了！！！");
        //生成地图和物体以及In_GameUI
        GameObject mapPrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "Map_1");
        GameObject map1 = GameObject.Instantiate(mapPrefab);
        map1.name = mapPrefab.name;
        Destroy(this.gameObject);
        UIMgr.Instance.ShowUI("In_Game_Page_view");
        //UIMgr.Instance.ShowUI("ChatBox_view");

        //生成角色
        GameObject Charfab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Char, "Char");
        GameObject Char1 = GameObject.Instantiate(Charfab);
        Char1.name = Charfab.name;
        Char1.AddComponent<Char_Control>();


        //设置相机跟踪
        GameObject CineMachineTarget = GameObject.FindGameObjectWithTag("CinemachineTarget");
        GameObject PlayerFollowCamera = GameObject.Find("PlayerFollowCamera");
        PlayerFollowCamera.GetComponent<CinemachineVirtualCamera>().Follow = CineMachineTarget.transform;

        //生成检查点
        GameObject CheckPoint = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Prop, "CheckPoint");
        GameObject CP = GameObject.Instantiate(CheckPoint);
        CP.name = CheckPoint.name;
        for(int i = 0;i< CheckPoint.transform.childCount; i++)
        {
            CP.transform.GetChild(i).gameObject.AddComponent<CheckPoint>();
        }

        //生成boss和slime小怪并添加脚本
        GameObject bossObj = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Char, "Boss");
        GameObject boss = GameObject.Instantiate(bossObj);
        boss.name = bossObj.name;
        GameObject boss_1 = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Char, "Boss_1");

        for (int i = 0; i < boss.transform.childCount; i+=2)
        {
            boss.transform.GetChild(i).gameObject.AddComponent<EnemySpawn>();
            boss.transform.GetChild(i).GetComponent<EnemySpawn>().enemy = boss_1;
            boss.transform.GetChild(i).GetComponent<EnemySpawn>().maxCount = 1;

            for (int j = 0; j < boss.transform.GetChild(i).transform.childCount; j++)
            {
                boss.transform.GetChild(i).GetComponent<EnemySpawn>().GeneratePoint[j] = boss.transform.GetChild(i).transform.GetChild(j).gameObject;
            }

        }
        for(int i = 1; i < boss.transform.childCount; i += 2)
        {
            boss.transform.GetChild(i).gameObject.AddComponent<EnemySpawn>();
            boss.transform.GetChild(i).GetComponent<EnemySpawn>().enemy = boss_1;
            boss.transform.GetChild(i).GetComponent<EnemySpawn>().maxCount = 1;

            for (int j = 0; j < boss.transform.GetChild(i).transform.childCount; j++)
            {
                boss.transform.GetChild(i).GetComponent<EnemySpawn>().GeneratePoint[j] = boss.transform.GetChild(i).transform.GetChild(j).gameObject;
            }

        }

        //添加小怪及脚本
        GameObject slimeObj = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Char, "Slime");
        GameObject slime = GameObject.Instantiate(slimeObj);
        slime.name = slimeObj.name;
        GameObject slime_1 = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Char, "Slime_1");
        //GameObject slimeIns = GameObject.Instantiate(slime_1);
        //slimeIns.name = slime_1.name;

        for (int i = 0; i < slime.transform.childCount; i++)
        {
            slime.transform.GetChild(i).gameObject.AddComponent<EnemySpawn>();
            slime.transform.GetChild(i).GetComponent<EnemySpawn>().enemy = slime_1;
            //slime.transform.GetChild(i).GetComponent<EnemySpawn>().GeneratePoint.
            for (int j = 0; j < slime.transform.GetChild(i).transform.childCount; j++)
            {
                slime.transform.GetChild(i).GetComponent<EnemySpawn>().GeneratePoint[j] = slime.transform.GetChild(i).transform.GetChild(j).gameObject;
            }

        }



    }

    void OnClickSetting()
    {
        Debug.Log("Setting被按了！！！");
    }

    void OnClickExit()
    {
        Debug.Log("Exit被按了！！！");
    }
}
