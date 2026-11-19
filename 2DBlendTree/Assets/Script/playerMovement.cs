using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;//导入新输入系统
using Cinemachine;
public class playerMovement : MonoBehaviour
{
    private Transform playerTransform;//用于储存对象的Transform组件
    private Animator animator;//用于储存对象的Animator组件

    [Header("Move Setting")]
    public float walkSpeed;//行走速度
    public float runSpeed;//奔跑速度
    public bool isRunning;//判断是否奔跑

    public Vector3 rotate;//旋转方向
    public float rotateSpeed;//旋转速度

    public Vector3 rifleRotateInput;

    [Header("Move Input")]
    public Vector2 moveInput;//储存移动输入信息

    [Header("rifle")]
    public bool isRifle;

    public CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;
    void Start()//获得相关组件
    {
        playerTransform = transform;
        animator = GetComponent<Animator>();
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    void Update()
    {
        playerMove();
        if(!isRifle)
            playerRotate();
        else
            playerRifleRotate();
    }

    public void getMoveInput(InputAction.CallbackContext callback){//接受玩家输入信息
        moveInput = callback.ReadValue<Vector2>();
        //Debug.Log(moveInput);
    }

    public void getRunInput(InputAction.CallbackContext callback)  {
        isRunning = callback.ReadValue<float>() > 0;//输入值大于零则为ture
    }

    public void getRifleInput(InputAction.CallbackContext callback)   {
        isRifle = callback.ReadValue<float>() > 0;
        animator.SetBool("rifle", isRifle); //赋值给Animator面板中的rifle变量
    }

    public void getRifleRotateInput(InputAction.CallbackContext callback)
    {
        rifleRotateInput = callback.ReadValue<Vector2>();
    }

    public void playerMove()
    {
        float targetSpeed;
        if (!isRifle)//角色持枪时无法奔跑只能走
        {
            targetSpeed = isRunning ? runSpeed : walkSpeed;
            //第三个参数为动作缓冲时间，防止人物僵硬
            animator.SetFloat("horizontalSpeed", 
                moveInput.magnitude * targetSpeed, 0.1f, Time.deltaTime);
        }
        else
        {
            targetSpeed = (moveInput.y > 0) ? walkSpeed : 0f;
            animator.SetFloat("horizontalSpeed", 
                moveInput.magnitude * targetSpeed, 0.1f, Time.deltaTime);
        }
    }

    public void playerRotate()
    {
        //避免松开操作角色会恢复原转向
        if (moveInput.Equals(Vector2.zero))//当输入为0时返回
            return;
   //定义三维向量为摄像机前方方向，ProjectOnPlane可获得向量在目标上的投影
        Vector3 cameraForwardDir = Vector3.ProjectOnPlane
            (Camera.main.transform.forward, Vector3.up).normalized;//第一个参数为场景中主相机的前景方向
                                                                   //第二个参数为目标平面的法向量
        //设置rotate的值
        rotate = cameraForwardDir * moveInput.y + Camera.main.transform.right * moveInput.x;

        Quaternion quaternion = Quaternion.LookRotation(rotate, Vector3.up);
   //RotateTowards可以将游戏对象从原本方向转移到目标方向
        playerTransform.rotation = Quaternion.RotateTowards
            (playerTransform.rotation, quaternion, rotateSpeed * Time.deltaTime);

        Vector3 targetDir = rotate;
   //转换到游戏对象的本地空间
        targetDir = playerTransform.InverseTransformVector(targetDir);
        float rad = Mathf.Atan2(targetDir.x, targetDir.z);//得到转向弧度值
        animator.SetFloat("turnSpeed", rad, 0.1f, Time.deltaTime);
    }

    public void playerRifleRotate()//定义人物持枪时的旋转方法
    {
        Vector3 mousePosition;//创建三维向量储存改变后的鼠标位置
        Ray ray = Camera.main.ScreenPointToRay(rifleRotateInput);//创建摄像机视线
        Plane plane = new Plane(Vector3.up, playerTransform.position);//建立角色位置水平面
        float distance;//定义变量，接收射线检测中输出的距离
        if (plane.Raycast(ray, out distance))
        {
            mousePosition = ray.GetPoint(distance);//根据距离得到视线上的点
        //根据鼠标到Z轴的距离改变偏移量
            float mouseDistance = (mousePosition - playerTransform.position).magnitude;
            mouseDistance = Mathf.Clamp(mouseDistance, 0f, 1.9f);
            framingTransposer.m_TrackedObjectOffset.z = mouseDistance + 0.1f;
            playerTransform.LookAt(mousePosition);//让角色转到该点
        }
    }
}
