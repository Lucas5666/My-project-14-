using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class Dyeing : MonoBehaviour
{

    private int BricksHp = 3;

    void Start()
    {
        
        Time.timeScale = 1;

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Bullet_BreakBricks"))
        {
            //碰撞时 砖块血量减1
            BricksHp--;

            switch (BricksHp)
            {
                //不同的血量会不同的颜色 每个砖块销毁时finalScore加1
                case 2:
                    this.gameObject.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
                    break;
                case 1:
                    this.gameObject.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                    break;
                case 0:
                    Destroy(this.gameObject);
                    GameObject.Find("BreakBricksCamera").transform.GetComponent<ScoreCheck>().finalScore++;
                    break;
            }


            
        }

    }



}
