using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    [SerializeField] private float fireRate = 0.5f;

    private float timer;

    private void Update()
    {
        if(Input.GetMouseButton(0))//GetMouseButtonDown一直按住鼠标左键进行发射
            Shot();
    }

    //经典的计时器限制频率问题
    public void Shot()
    {
        timer += Time.deltaTime;
        if(timer > fireRate)
        {
            timer = 0;
            GameObject spawnProjectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
}
