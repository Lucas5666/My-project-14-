using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float speed = 100f; 

    void Update()
    {
        
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}