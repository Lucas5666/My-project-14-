using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Diagnostics.Tracing;


public class UICtrl : MonoBehaviour
//,IPointerDownHandler,IPointerClickHandler,IPointerUpHandler
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



    public void AddOnPointerDown(string viewName, UIEventListener.PointerEventHandler PointerDown)
    {
        UIEventListener obj = null;
        if (!this.view[viewName].GetComponent<UIEventListener>())
        {
            obj = this.view[viewName].AddComponent<UIEventListener>();
        }
        else
        {
            obj = this.view[viewName].GetComponent<UIEventListener>();
        }

        obj.PointerDown += PointerDown;
    }

    public void AddOnPointerClick(string viewName, UIEventListener.PointerEventHandler PointerClick)
    {
        UIEventListener obj = null;
        if (!this.view[viewName].GetComponent<UIEventListener>())
        {
            obj = this.view[viewName].AddComponent<UIEventListener>();
        }
        else
        {
            obj = this.view[viewName].GetComponent<UIEventListener>();
        }

        obj.PointerClick += PointerClick;
    }

    public void AddOnPointerUp(string viewName, UIEventListener.PointerEventHandler PointerUp)
    {
        UIEventListener obj = null;
        if (!this.view[viewName].GetComponent<UIEventListener>())
        {
            obj = this.view[viewName].AddComponent<UIEventListener>();
        }
        else
        {
            obj = this.view[viewName].GetComponent<UIEventListener>();
        }

        obj.PoinertUp += PointerUp;
    }
}

public class UIEventListener : UICtrl,IPointerDownHandler
{
    public delegate void PointerEventHandler(PointerEventData eventData);

    public event PointerEventHandler PointerDown;
    public event PointerEventHandler PointerClick;
    public event PointerEventHandler PoinertUp;



    public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown(eventData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PointerClick(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PoinertUp(eventData);
    }

}
