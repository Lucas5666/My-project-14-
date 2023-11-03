using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ElfPoolPointView_Ctrl: UICtrl 
 {

    private int numberOfCheck = 5;
    private GameObject block;

    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        this.AddButtonListener("Exit", onClickExit);

        this.AddButtonListener("IAlreadyHave", onClickIAlreadyHave);

        block = GameObject.Find("ElfPoolPointENTBlock");

        
    }

    private void onClickIAlreadyHave()
    {
        print("onClickIAlreadyHave");
        print(block == null);
        MedalsCheck.MedalsCheck1(numberOfCheck, block);
        Destroy(this.gameObject);
    }

    void onClickExit()
    {
        Destroy(this.gameObject);
    }
}
