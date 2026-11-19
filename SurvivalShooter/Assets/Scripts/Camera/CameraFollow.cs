using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;//平滑度

    Vector3 offset;//偏移量

    void Start()
    {   //相机减去角色的位置得到相机到角色的向量
        offset = transform.position - target.position;
    }

    void FixedUpdate()//如果用Update，它就会和玩家时间错开
    {
        Vector3 targetCampos = target.position + offset;
        //移动相机位置
        transform.position = Vector3.Lerp(
            transform.position, targetCampos, smoothing * Time.deltaTime);
    }

}
