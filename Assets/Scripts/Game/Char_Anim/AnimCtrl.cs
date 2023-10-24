using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayState
{
    Invalid = -1,
    Walk = 0,
    Idle = 2,
    Jump = 3,
    InAir = 4,
    Drop = 5,

    Attack = 6,
    Attack2 = 7,
    Death = 8,
}

public class AnimCtrl : MonoBehaviour
{
    private Animator anim = null;
    private int state = (int)PlayState.Invalid;

    public void Init()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }

    public void setState(int state)
    {
        if (this.state == state)
            return;

        this.state = state;
        //播放动画
        //anim.Play()
    }
}
