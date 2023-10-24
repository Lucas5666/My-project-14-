using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char_Control : MonoBehaviour
{
    Animator ani = null;
    private void Start()
    {
        ani = GameObject.Find("Char").GetComponent<Animator>();
    }

    private void Update()
    {
        Fire();
    }

    public void Fire()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            ani.Play("Attack");
        }
    }
}
