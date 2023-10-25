using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    Transform target = null;
    //private Transform canvas = null;
    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.Find("Canvas").transform;

        if (GameObject.FindWithTag("Player").transform != null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("开始碰撞了");
        if (other.gameObject.name == target.gameObject.name)
        {
            Debug.Log("hh");
            UIMgr.Instance.ShowUI(this.gameObject.name);
        }
        Debug.Log("碰撞结束了");
    }

}
