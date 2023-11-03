using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FinalPointView_Ctrl: UICtrl 
 {

    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        this.AddButtonListener("Exit", onClickExit);
    }

    void onClickExit()
    {
        Destroy(this.gameObject);
    }
}
