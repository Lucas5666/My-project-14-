using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHide : MonoBehaviour
{
    private GameObject HideItem;
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled=false;
        HideItem = TransformHelper.FindChild(this.transform.parent, this.gameObject.name + "Block").gameObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HideItem.transform.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HideItem.transform.GetComponent<Renderer>().enabled = false;
        }
    }



}
