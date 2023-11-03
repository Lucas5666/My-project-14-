using System.Collections;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;
using UnityEngine;

public class AddMedal : MonoBehaviour
{
    bool medalRecord;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MonsterStatus>().onDeath += onDeath;
        if (this.gameObject.name.StartsWith("Monster_1"))
            medalRecord = MedalRecord.Monster_1;
        if (this.gameObject.name.StartsWith("Monster_2"))
            medalRecord = MedalRecord.Monster_2;
        if (this.gameObject.name.StartsWith("Monster_3"))
            medalRecord = MedalRecord.Monster_3;
    }

    // Update is called once per frame
    void onDeath()
    {
        if (!medalRecord)
        {
            PlayerStatus.medalNum++;
            medalRecord = true;
        }
    }
}
