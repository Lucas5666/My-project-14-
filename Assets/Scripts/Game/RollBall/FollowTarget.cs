using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform playerTransform;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = TransformHelper.FindChild(this.transform.parent, "Player");
        offset = transform.position - playerTransform.position;
        //Vector3 offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
            transform.LookAt(playerTransform);
        }

        //print(Time.time);
    }
}
