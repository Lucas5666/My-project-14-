using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaiLu_LegendOfValmosian;

[RequireComponent(typeof(Rigidbody))] 
public class PlayerBullet : MonoBehaviour
{
    //伤害量
    public int _damageAmount = 1;

    private void Start()
    {
        Destroy(this.gameObject, 1);    
    }
    //碰撞时造成伤害
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy_1"  )
        {
            collision.gameObject.GetComponent<CharacterStatus>().OnDamage(_damageAmount);
            collision.transform.Translate(-Vector3.forward * 2);
            
        }

    }
}
