using UnityEngine;
using CaiLu_LegendOfValmosian;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : CharacterStatus
{
    private Rigidbody rb;
    private Vector3 moveInput;
    [SerializeField] private float moveSpeed = 8;
    private float timer;
    private Camera cam;

    //重写父方法 
    protected  void Start()
    {
        HP = MaxHP;
        rb = GetComponent<Rigidbody>();
        cam = TransformHelper.FindChild(this.transform.parent, "ShootingGameCamera").GetComponent<Camera>();
        this.onDeath += Deadth;

    }

    //移动并注视鼠标位置 时间计时器
    private void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        LookAtCursor();
        timer += Time.deltaTime;
    }

    //移动
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }

    //注视鼠标的位置
    private void LookAtCursor()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float distToGround;
        if (plane.Raycast(ray, out distToGround))
        {
            Vector3 point = ray.GetPoint(distToGround);
            Vector3 rightPoint = new Vector3(point.x, transform.position.y, point.z);

            transform.LookAt(rightPoint);
        }
    }

    //被敌人触碰到后 自己造成伤害
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy_1") && timer >0.3f)
        {
            OnDamage(1);
            this.transform.Translate(-new Vector3(0, 0, 0.4f));
            timer = 0;
        }
    }

    public  void Deadth()
    {
        UIMgr.Instance.ShowUI("ShootingGameFailedView");
        PlayerStatus.PlayerGO.GetComponent<PlayerStatus>().HP = (int)MonsterPlatformView_Ctrl.BeforeCharHealth;
    }
}
