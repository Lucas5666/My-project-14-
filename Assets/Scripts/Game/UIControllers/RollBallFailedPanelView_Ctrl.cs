using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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
        Destroy(GameObject.Find("RollBallMap"));
        Destroy(this.gameObject);
        Time.timeScale = 1;
        RiverSidePointView_Ctrl.PlayerGO.SetActive(true);

    }

    void onClickTryAgain()
    {
        Destroy(this.gameObject);
        Player.countDownSecond = 17;
    }
}
