using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    private Transform firePoint;
    private GameObject bullet;
    private Transform aim;
    private float shootSpeed = 50;
    private float bulletSpeed = 100;
    [SerializeField] private float fireRate = 0.25f;

    private float timer;

    private void Start()
    {
        firePoint = this.transform;
        aim = TransformHelper.FindChild(this.transform.parent, "Aim");
        bullet = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Props, "Bullet_2");
    }

    private void Update()
    {
        //当鼠标按下时，执行射击方法，并播放动画
        if (Input.GetMouseButton(0))
        {
            Shot();
            GetComponentInParent<Animator>().Play("shooting");
        }
            
    }

    public void Shot()
    {
        //计时器避免短时间内 太多次射击 当射击间隔大于fireRate时可以再次发射子弹
        timer += Time.deltaTime;
        if(timer > fireRate)
        {
            ////生成子弹 
            //GameObject spawnProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            //spawnProjectile.AddComponent<PlayerBullet>();
            ////让子弹朝着一定的方向和速度运动
            //spawnProjectile.transform.GetComponent<Rigidbody>().AddForce((aim.transform.position - this.transform.position) * bulletSpeed, ForceMode.Impulse);
            ////计时器归零
            //timer = 0;


            GameObject obj = GameObjectPool.Instance.CreateObject("bullet", bullet, transform.position, transform.rotation);
            obj.AddComponent<PlayerBullet>();
            obj.transform.GetComponent<Rigidbody>().AddForce((aim.transform.position - this.transform.position) * bulletSpeed, ForceMode.Impulse);
            timer = 0;
        }
    }


}
