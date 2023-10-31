using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("DoFire", 0.05f,0.05f);
    }
    public void DoFire()
    {
        
        if (Input.GetMouseButton(0))
        {
            GameObject bulletFrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Map, "BreakBricksMap/Bullet");
            GameObject bullet = GameObject.Instantiate(bulletFrefab, transform.position, transform.rotation);
            Destroy(bullet, 1.5f);
            bullet.name = bulletFrefab.name;
            Rigidbody rd = bullet.GetComponent<Rigidbody>();
            rd.velocity = Vector3.forward * 100;
        }
 
    }

}
