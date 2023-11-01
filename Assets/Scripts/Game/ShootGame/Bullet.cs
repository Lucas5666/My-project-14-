using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float shootSpeed = 50;
    [SerializeField] private float damage = 1.0f;
    [SerializeField] private float lifetime = 1;

    public LayerMask collisionLayerMask;

    private void Start()
    {
        //当子弹发射过了lifetime秒后，子弹需要被销毁，避免一直在场景中消耗性能
        Destroy(gameObject, lifetime);
        collisionLayerMask = LayerMask.GetMask("Enemy");
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * shootSpeed * Time.deltaTime);
        CheckCollision();
    }

    private void CheckCollision()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        //射线击中目标的具体信息
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, shootSpeed * Time.deltaTime, collisionLayerMask, QueryTriggerInteraction.Collide))
        {
            //击中敌人了，敌人要受伤了
            HitEnemy(hitInfo);
        }
    }

    private void HitEnemy(RaycastHit _hitInfo)
    {
        EnemyInShootingGame damageable = _hitInfo.collider.GetComponent<EnemyInShootingGame>();

        _hitInfo.transform.Translate(-Vector3.forward);
        _hitInfo.transform.GetComponent<MeshRenderer>().material.color = Color.red;

        if (damageable != null)
            damageable.OnDamage(1);

        Destroy(gameObject);//当子弹击中敌人后，子弹需要被销毁
    }

}
