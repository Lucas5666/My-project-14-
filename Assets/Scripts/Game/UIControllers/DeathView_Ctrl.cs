using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DeathView_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
		this.AddButtonListener("BackToMenu", onClick);
	}

	void onClick()
	{
		UIMgr.Instance.ShowUI("StartMenu_View");
		Destroy(this.gameObject);
		Destroy(GameObject.Find("Map_1"));
		Destroy(GameObject.Find("Char"));
	}
}
