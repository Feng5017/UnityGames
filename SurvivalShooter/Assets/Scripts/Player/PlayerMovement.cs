using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f; //从相机发射的射线的长度

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
    //获得Animator组件和Rigidbody的信息
        anim = GetComponent<Animator>(); 
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()//Unity的自动更新函数
    {
        float h = Input.GetAxisRaw("Horizontal");//获得默认水平轴（A D键）
        float v = Input.GetAxisRaw("Vertical");//获得默认垂直轴（W S键）

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)//角色的移动
    {
        movement.Set(h, 0f, v);
    //一秒五十次更新才移动6f
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()//角色的朝向，从摄像机出发，沿鼠标方向
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);    
        RaycastHit floorHit;//获得摄像机视线返回的信息

        if(Physics.Raycast(camRay,out floorHit, camRayLength, floorMask))
        {   //目标位置-角色位置=角色到目标的一条向量
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            //储存旋转
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = (h != 0f || v != 0f);//如果竖向和横向都有输入就是walking状态的动画
        anim.SetBool("IsWalking", walking);//调用Animator面板中的参数
    }
}
