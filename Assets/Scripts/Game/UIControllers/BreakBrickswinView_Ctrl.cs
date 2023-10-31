using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class BreakBrickswinView_Ctrl: UICtrl 
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
        //Destroy(GameObject.Find("BreakBricksMap"));
        Destroy(this.gameObject);
        Time.timeScale = 1;
        //Destroy(TransformHelper.FindChild(UIMgr.canvas, "BreakBricksMap").gameObject);
        PlayerStatus.PlayerGO.SetActive(true);


    }
}
