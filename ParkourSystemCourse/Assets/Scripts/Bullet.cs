using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 50;
    public float speed = 40;
    public GameObject explosionEffectPrefab;
    private Transform target;

    public void SetTarget(Transform _target)
    {
        this.target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Die();
            return;
        }

        transform.LookAt(target.position);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy1>().TakeDamage(damage);
            Die();
        }
    }

    void Die()
    {
        GameObject effect = GameObject.Instantiate(explosionEffectPrefab, transform.position, transform.rotation);//增加特效
        Destroy(effect, 1);
        Destroy(this.gameObject);//销毁这个游戏物体,如果只是this，只是销毁Bullet组件
    }
}
