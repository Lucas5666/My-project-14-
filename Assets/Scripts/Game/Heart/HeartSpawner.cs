using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    GameObject heartPrefab;
    // Start is called before the first frame update
    void Start()
    {
        heartPrefab = ResMgr.Instance.GetMapAssets<GameObject>(AssetsType.Props, "Heart");
        for (int i = 0; i < this.transform.childCount; i++)
        {
            print(this.transform.childCount);
            GameObject heart = Instantiate(heartPrefab, this.transform.GetChild(i).position, Quaternion.identity);
            heart.transform.SetParent(this.transform);
            heart.AddComponent<AddHealthPoint>();
            heart.AddComponent<Rotation>();

        }
    }

}
