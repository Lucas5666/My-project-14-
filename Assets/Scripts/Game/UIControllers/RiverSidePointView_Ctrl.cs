using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RiverSidePointView_Ctrl: UICtrl 
 {
    public static GameObject PlayerGO = null;
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        PlayerGO = GameObject.FindWithTag("Player");
        this.AddButtonListener("Exit", onClickExit);
        this.AddButtonListener("Play", onClickPlay);
    }

    void onClickExit()
    {
        Destroy(this.gameObject);
    }
    void onClickPlay()
    {
        GameObject RollBallMapFrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "RollBallMap");
        GameObject RollBallMap = GameObject.Instantiate(RollBallMapFrefab);
        RollBallMap.name = RollBallMapFrefab.name;
        Destroy(this.gameObject);

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
        PlayerGO.SetActive(false);

    }
}
