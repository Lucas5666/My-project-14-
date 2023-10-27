using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GressLandPointView_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
		this.AddButtonListener("Doit", OnDoitClick);
		this.AddButtonListener("Exit", OnExitClick);
	}

	void OnDoitClick()
	{

	}

	void OnExitClick()
	{
        Destroy(this.gameObject);
    }
}
