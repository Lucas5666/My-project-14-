using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollBallControl : MonoBehaviour
{
    // Start is called before the first frame update

    private DefaultInputActions inputControl;

    private Vector2 vh;

    private float speed = 200;

    private Rigidbody rd;

    private void Awake()
    {
        inputControl = new DefaultInputActions();
    }
    void Start()
    {
        rd = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    

    private void OnEnable()
    {
        inputControl.Enable();
    }

    private void OnDisable()
    {
        inputControl.Disable();
    }


    public void Controler()
    {

    }

    void Update()
    {
        vh = inputControl.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        rd.velocity = new Vector3(vh.x * speed * Time.deltaTime,0, vh.y * speed * Time.deltaTime);
    }
}
