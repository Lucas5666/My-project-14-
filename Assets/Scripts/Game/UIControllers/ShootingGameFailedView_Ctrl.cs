using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class ShootingGameFailedView_Ctrl: UICtrl 
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
        Destroy(GameObject.Find("ShootingGameMap"));
        Destroy(this.gameObject);
        Time.timeScale = 1;
        PlayerStatus.PlayerGO.SetActive(true);
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").gameObject);
        PlayerStatus.PlayerGO.GetComponent<PlayerStatus>().HP = (int)MonsterPlatformView_Ctrl.BeforeCharHealth;
    }

    void onClickTryAgain()
    {
        Destroy(GameObject.Find("ShootingGameMap"));
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").gameObject);
        MonsterPlatformView_Ctrl.InitShootingGame();
        Destroy(this.gameObject);
    }
}
