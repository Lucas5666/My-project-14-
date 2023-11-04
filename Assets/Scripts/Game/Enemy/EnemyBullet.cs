using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaiLu_LegendOfValmosian;

[RequireComponent(typeof(Rigidbody))]
public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 1;

    private void Start()
    {
        Destroy(this.gameObject, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<CharacterStatus>().OnDamage(damage);
        }
    }

}
