using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaiLu_LegendOfValmosian;

public class AddHealthPoint : MonoBehaviour
{
    private int AddNum = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && PlayerStatus.PlayerGO != null)
        {
            other.gameObject.GetComponent<PlayerStatus>().AddHealth(AddNum);
            Destroy(this.gameObject, 0.3f);
        }
            

    }
}
