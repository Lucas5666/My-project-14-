using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class ShootingGameWinView_Ctrl: UICtrl 
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
        Destroy(GameObject.Find("ShootingGameMap"));
        Destroy(this.gameObject);
        Time.timeScale = 1;
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "RollBallScoreView").gameObject);
        PlayerStatus.PlayerGO.SetActive(true);


    }
}
