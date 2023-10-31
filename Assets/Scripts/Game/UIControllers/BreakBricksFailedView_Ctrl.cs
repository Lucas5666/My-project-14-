using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class BreakBricksFailedView_Ctrl: UICtrl 
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
        Destroy(GameObject.Find("BreakBricksMap"));
        Destroy(this.gameObject);
        Time.timeScale = 1;
        PlayerStatus.PlayerGO.SetActive(true);
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").gameObject);
    }

    void onClickTryAgain()
    {
        //Destroy(GameObject.Find("BreakBricksMap"));
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksScore").gameObject);
        GressLandPointView_Ctrl.InitBreakBricksGame();
        Destroy(this.gameObject);
    }
}
