using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//UI管理工具
public class UIMgr : UnitySingleton<UIMgr>
{
    private Transform canvas = null;
    string ui_Prefab_root = "GUI/UIPrefabs/";

    public override  void Awake()
    {
        base.Awake();
        canvas = GameObject.Find("Canvas").transform;
    }

    public UICtrl ShowUI(string name,Transform parent = null)
    {
        GameObject uiPrefab = ResMgr.Instance.GetAssetsCache<GameObject>(ui_Prefab_root + name + ".prefab");

        GameObject uiView = GameObject.Instantiate(uiPrefab);
        uiView.name = name;
        if(parent == null)
        {
            parent = this.canvas.transform;
        }
        uiView.transform.SetParent(parent, false);

        Type type = Type.GetType(name + "_Ctrl");
        UICtrl ctrl = (UICtrl)uiView.AddComponent(type);
        return ctrl;
    }
}
