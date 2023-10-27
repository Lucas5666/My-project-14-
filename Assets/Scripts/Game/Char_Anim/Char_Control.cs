using System.Collections;
using System.Collections.Generic;
using CaiLu_LegendOfValmosian;
using UnityEngine;

public class Char_Control : MonoBehaviour
{
    Animator ani = null;
    SkillData Skill_1 = null;
    CharacterSkillManager charSkillMgr = null;

    private void Start()
    {
        ani = this.gameObject.GetComponent<Animator>();
        charSkillMgr = GetComponent<CharacterSkillManager>();

    }

    private void Update()
    {
        Fire();

    }

    public void Fire()
    {

        if (Input.GetKey(KeyCode.Q))
        {
            ani.Play("Attack");
            Skill_1 = charSkillMgr.PrepareSkill(1);
            if (Skill_1 != null)
                charSkillMgr.DeploySkill(Skill_1);

        }
    }
}
