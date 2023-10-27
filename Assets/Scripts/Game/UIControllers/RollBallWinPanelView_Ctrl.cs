using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

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
		Destroy(GameObject.Find("RollBallMap"));
		Destroy(this.gameObject);
        Time.timeScale = 1;
        RiverSidePointView_Ctrl.PlayerGO.SetActive(true);

    }
}
