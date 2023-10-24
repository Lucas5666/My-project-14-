using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameLaunch : UnitySingleton<GameLaunch>
{
    public override void Awake()
    {
        base.Awake();
        //初始化 游戏框架模块 资源模块 声音模块 网络模块 日志模块 协议模块

        //this.gameObject.AddComponent<GameApp>();
        //this.gameObject.AddComponent<ResMgr>();

        //初始化xlua框架

        //检查更新
        this.CheckHotUpdate();

    }
    // Start is called before the first frame update
    void Start()
    {
        //检查游戏更新

        GameApp.Instance.EnterGame(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitFrameWork()
    {
        this.gameObject.AddComponent<ResMgr>();
        this.gameObject.AddComponent<UIMgr>();
    }

    private void InitGameLogic()
    {
        this.gameObject.GetComponent<GameApp>();
        GameApp.Instance.InitGAme();

    }

    private void CheckHotUpdate()
    {
        //获取服务器资源/代码版本
        //拉取下载列表
        //下载资源到本地

    }
}
