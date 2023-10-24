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
        //生成地图和物体
        GameObject mapPrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "Map_1");
        GameObject map1 = GameObject.Instantiate(mapPrefab);
        map1.name = mapPrefab.name;
        Destroy(this.gameObject);
        UIMgr.Instance.ShowUI("In_Game_Page_view");

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
