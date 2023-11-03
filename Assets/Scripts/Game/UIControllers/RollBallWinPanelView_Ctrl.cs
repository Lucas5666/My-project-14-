using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class RollBallWinPanelView_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
		this.AddButtonListener("WinAndBack", onClick);

    }

    void onClick()
	{
		//Destroy(GameObject.Find("RollBallMap"));
		Destroy(this.gameObject);
        Time.timeScale = 1;
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "RollBallScoreView").gameObject);
        PlayerStatus.PlayerGO.SetActive(true);


    }
}
