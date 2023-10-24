using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class UICtrl : MonoBehaviour
{
    //生成视图 字典 view 》》filepath
    public Dictionary<string, GameObject> view = new Dictionary<string, GameObject>();

    public virtual void Awake()
    {
        this.LoadAllGameObjectToView(this.gameObject,"");
    }


    private void LoadAllGameObjectToView(GameObject root,string path)
    {
        foreach(Transform tf in root.transform)
        {
            if(this.view.ContainsKey(path + tf.gameObject.name))
            {
                continue;
            }
            this.view.Add(path + tf.gameObject.name, tf.gameObject);
            LoadAllGameObjectToView(tf.gameObject, path + tf.gameObject.name + "/");
            //Debug.Log(path + tf.gameObject.name + "/");
        }
    }

    public void AddButtonListener(string viewName, UnityAction onClick)
    {
        Button bt = this.view[viewName].GetComponent<Button>();
        if(bt == null)
        {
            Debug.Log("no button");
            return;
        }
        bt.onClick.AddListener(onClick);
    }
}
