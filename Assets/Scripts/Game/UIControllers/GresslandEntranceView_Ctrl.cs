using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using CaiLu_LegendOfValmosian;

public class GresslandEntranceView_Ctrl: UICtrl 
 {
    private int numberOfCheck = 3;
    private GameObject block;

    public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
        this.AddButtonListener("Exit", onClickExit);
        
        this.AddButtonListener("IAlreadyHave", onClickIAlreadyHave);

        block = GameObject.Find("GressLandENT");

    }

    private void onClickIAlreadyHave()
    {
        MedalsCheck.MedalsCheck1(numberOfCheck, block);
        Destroy(this.gameObject);
    }

    void onClickExit()
	{
        Destroy(this.gameObject);
    }

    

}
