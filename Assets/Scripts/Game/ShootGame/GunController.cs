using UnityEngine;

public class GunController : MonoBehaviour
{
    private Transform firePoint;
    private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 0.1f;

    private float timer;
    private void Start()
    {
        firePoint = TransformHelper.FindChild(this.transform, "FirePoint");
        bulletPrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Props, "Bullet");
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))//GetMouseButtonDown一直按住鼠标左键进行发射
            Shot();
    }

    //计时器限制频率问题
    public void Shot()
    {
        timer += Time.deltaTime;
        if(timer > fireRate)
        {
            timer = 0;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.AddComponent<Bullet>();
        }
    }
}
