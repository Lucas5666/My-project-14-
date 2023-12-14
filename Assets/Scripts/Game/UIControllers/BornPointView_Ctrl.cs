using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BornPointView_Ctrl: UICtrl 
 {  
 
	public override void Awake() 
	{
		base.Awake();	
	}	
	void Start() 
	{
		this.AddButtonListener("Exit", onClick);
		//this.AddOnPointerDown("Exit", PointerDown);
    }

	void onClick()
	{
		Destroy(this.gameObject);
	}

 //   /public void PointerDown(PointerEventData eventData)
	//{
	//	Debug.Log("PointerDown");
	//}

}
