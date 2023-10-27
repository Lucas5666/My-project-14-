using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class RiverSidePoint_Ctrl: UICtrl 
 {

    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {

        this.GetComponent<Button>().onClick.AddListener(onClick);
    }

    void onClick()
    {
        UIMgr.Instance.ShowUI(this.gameObject.name + "View");
        Destroy(this.gameObject);
    }
}
