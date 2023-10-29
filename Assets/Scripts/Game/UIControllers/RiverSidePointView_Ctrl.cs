using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class RiverSidePointView_Ctrl: UICtrl 
 {
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        this.AddButtonListener("Exit", onClickExit);
        this.AddButtonListener("Play", onClickPlay);
    }

    void onClickExit()
    {
        Destroy(this.gameObject);
    }
    void onClickPlay()
    {
        InitRollBallGame();
        Destroy(this.gameObject);

    }

    public static void InitRollBallGame()
    {
        Player.countDownSecond = 17;
        GameObject RollBallMapFrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "RollBallMap");
        GameObject RollBallMap = GameObject.Instantiate(RollBallMapFrefab);
        RollBallMap.name = RollBallMapFrefab.name;

        Transform camera = TransformHelper.FindChild(RollBallMap.transform, "Camera");
        camera.gameObject.AddComponent<FollowTarget>();
        Transform player = TransformHelper.FindChild(RollBallMap.transform, "Player");
        player.gameObject.AddComponent<Player>();
        player.gameObject.AddComponent<RollBallControl>();


        foreach (var item in GameObject.FindGameObjectsWithTag("Food"))
        {
            item.gameObject.AddComponent<Food>();
        }

        UIMgr.Instance.ShowUI("RollBallScoreView");
        PlayerStatus.PlayerGO.SetActive(false);
    }
}
