using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //可被序列化
public class Wave {     //只保存没一波敌人生成所需要的属性，所以不用继承MonoBehaviour类
    public GameObject enemyPrefab;
    public int count;
    public float rate;
   
}
