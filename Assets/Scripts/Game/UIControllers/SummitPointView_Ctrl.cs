using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;

public class SummitPointView_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
        this.AddButtonListener("Exit", OnExitClick);

    }

	void OnExitClick()
	{
        if (!MedalRecord.SummitPoint)
        {
            PlayerStatus.medalNum++;
            MedalRecord.SummitPoint = true;
        }
        Destroy(this.gameObject);
    }
}
