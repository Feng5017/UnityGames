using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{
    public float speed = 20;
    public float mouseSpeed = 600;
    void Update() {
    //用键盘上的WSAD键控制摄像机前后左右移动
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");  
    //用鼠标滑轮控制上下移动
        float mouse = Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(h * speed, mouse * mouseSpeed, v * speed) * Time.deltaTime, Space.World);
    }
}
