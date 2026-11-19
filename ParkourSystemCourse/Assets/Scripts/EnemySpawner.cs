using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static int CountEnemyAlive = 0; //初始化存活敌人数量
    public Wave[] waves;
    public Transform START;
    public float waveRate = 0.2f;
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }
    public void Stop()
    {
        StopCoroutine("SpawnEnemy");
    }
    IEnumerator SpawnEnemy(){
        foreach (Wave wave in waves){        
            for (int i = 0; i < wave.count; i++){ 
              //根据Prefab生成到开始位置
                GameObject.Instantiate(wave.enemyPrefab, START.position, Quaternion.identity);
                CountEnemyAlive++;          //生成一个敌人则数量加一
                if (i != wave.count - 1)        //上一批生成完才可生成下一个
                    yield return new WaitForSeconds(wave.rate);
            }
            while (CountEnemyAlive > 0)
                yield return 0;
            yield return new WaitForSeconds(waveRate);
        }
        while (CountEnemyAlive > 0)
        {
            yield return 0;
        }
        GameManager.Instance.Win();
    }
}
