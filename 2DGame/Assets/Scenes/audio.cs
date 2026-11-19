using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public float moveSpeed = 5.0f;//移动速度
    Vector2 movement;//移动方向
    public Rigidbody2D Rb;

    public Animator animator;

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");//获得水平轴
        movement.y = Input.GetAxisRaw("Vertical");//获得垂直轴

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(0))//鼠标响应时执行Attack()
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attacking"))
        {   //若在播放Attack动作，则不更新位置
            Rb.MovePosition(Rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");//触发时自动播放Attack
    }

}
