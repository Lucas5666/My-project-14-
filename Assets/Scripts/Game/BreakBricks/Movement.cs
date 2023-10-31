using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update

    private DefaultInputActions inputControl;

    private Vector2 vh;

    private float speed = 10;

    private void Awake()
    {
        inputControl = new DefaultInputActions();
    }
    void Start()
    {

    }

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }

    void Update()
    {
        vh = inputControl.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        this.transform.Translate(vh.x * speed * Time.deltaTime, vh.y * speed * Time.deltaTime, 0);

    }

}
