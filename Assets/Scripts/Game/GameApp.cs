using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameApp : UnitySingleton<GameApp>
{

    //游戏逻辑的总入口
    public void EnterGame()
    {
        Debug.Log("进入游戏了！！！");
        this.EnterGameScene();
    }

    public void InitGAme()
    {

    }

    private void EnterGameScene()
    {
        //释放游戏地图 释放Npc 角色 UI等

        //GameObject uiPrefab = ResMgr.Instance.GetAssetsCache<GameObject>("GUI/UIPrefabs/aaa.prefab" );
        //GameObject ui_view = GameObject.Instantiate(uiPrefab);
        //Transform canvas = GameObject.Find("Canvas").transform;
        //ui_view.transform.SetParent(canvas,false);

        UIMgr.Instance.ShowUI("StartMenu_View");
        //UIMgr.Instance.ShowUI("hhh");


    }
}
