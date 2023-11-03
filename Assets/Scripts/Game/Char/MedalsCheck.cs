using System.Collections;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;
using UnityEngine;

public class MedalsCheck : MonoBehaviour
{
    public static void MedalsCheck1(int numberOfCheck,GameObject block)
    {

        //比较勋章数量 符合要求将设置碰撞器为触发器 玩家可以通过
        if (PlayerStatus.medalNum >= numberOfCheck)
        {
            print("MedalsCheck1");
            if (block.transform.GetComponent<Collider>() != null)
            {
                block.transform.GetComponent<Collider>().isTrigger = true;

            }
            //if(block.transform.GetComponent<SphereCollider>() != null)
            //{
            //    block.transform.GetComponent<SphereCollider>().isTrigger = true;
            //}
            print("MedalsCheck1......");

            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 1;
        }

    }
}
