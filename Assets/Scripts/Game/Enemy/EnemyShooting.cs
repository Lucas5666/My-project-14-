using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaiLu_LegendOfValmosian;

public class EnemyShooting : MonoBehaviour
{
    public float CheckDis = 5;
    private float dis;
    private Transform target;

    public float shotRate = 4;
    private float timer;

    public GameObject projectilePrefab;
    public float bulletSpeed = 10;

    public Transform firePoint;
    public Transform aim;

    //获取角色变换组件
    void Start()
    {
        if (PlayerStatus.PlayerGO != null)
        {
            target = PlayerStatus.PlayerGO.transform;
        }
        projectilePrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Props, "Bullet_3");

        firePoint = TransformHelper.FindChild(this.transform, "FirePoint");
        aim = TransformHelper.FindChild(this.transform, "AimPoint");
    }

    //检测距离 距离合适时 射击并播放动画
    void Update()
    {
        if(target != null)
        {
            dis = Vector3.Distance(target.position, this.transform.position);

            timer += Time.deltaTime;
            if (dis < CheckDis && timer > shotRate)
            {
                shot();
                GetComponent<Animator>().Play("Fire");
            }
        }
        
    }

    //射击 生成子弹并飞出
    public void shot()
    {
        GameObject spawnProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        spawnProjectile.AddComponent<EnemyBullet>();
        spawnProjectile.transform.GetComponent<Rigidbody>().AddForce((aim.transform.position - this.transform.position) * bulletSpeed, ForceMode.Impulse);
        timer = 0;
    }
}
