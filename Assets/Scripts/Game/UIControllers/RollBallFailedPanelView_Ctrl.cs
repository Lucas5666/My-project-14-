using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class RollBallFailedPanelView_Ctrl: UICtrl 
 {

    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        this.AddButtonListener("Back", onClickBack);
        this.AddButtonListener("TryAgain", onClickTryAgain);

    }

    void onClickBack()
    {
        //Destroy(GameObject.Find("RollBallMap"));
        Destroy(this.gameObject);
        Time.timeScale = 1;
        PlayerStatus.PlayerGO.SetActive(true);
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "RollBallScoreView").gameObject);
    }

    void onClickTryAgain()
    {
        //Destroy(GameObject.Find("RollBallMap"));
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "RollBallScoreView").gameObject);
        RiverSidePointView_Ctrl.InitRollBallGame();
        Destroy(this.gameObject);
    }
}
