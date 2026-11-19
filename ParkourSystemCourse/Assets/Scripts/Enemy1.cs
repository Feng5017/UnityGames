using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy1 : MonoBehaviour
{
    private Transform[] positions;
    private int index = 0;
    private float totalHp;

    public float speed = 10;
    public float hp = 150;
    public GameObject explosionEffect;
    private Slider hpSlider;

    void Start(){
        positions = Waypoints.positions;
        totalHp = hp;
        hpSlider = GetComponentInChildren<Slider>();
    }

    void Update(){
        Move();
    }

    void Move(){
        if (index > positions.Length - 1)
            return;
        transform.Translate((positions[index].position - transform.position).normalized * Time.deltaTime * speed);
        if (Vector3.Distance(positions[index].position, transform.position) < 0.2f)     //判断是否到达终点
        {
            index++;
            if (index > positions.Length - 1)
            {
                ReachDestination();
            }
        }
    }

    internal void TakeDamage(object damage)
    {
        throw new NotImplementedException();
    }

    void ReachDestination()     //到达终点
    {
        GameManager.Instance.Failed();
        GameObject.Destroy(this.gameObject);
        //OnDestory();
    }

    void OnDestory()    //被炮塔销毁或到终点销毁
    {
        EnemySpawner.CountEnemyAlive--;
    }

    public void TakeDamage(float damage)  //受到的伤害
    {
        if (hp <= 0)
            return;
        hp -= damage;
        hpSlider.value = (float)hp / totalHp;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(effect, 1.5f);
        Destroy(this.gameObject);
        EnemySpawner.CountEnemyAlive--;
    }
}
