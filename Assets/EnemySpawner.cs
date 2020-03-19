using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    Transform stageTransform;
    public GameObject Enemy;
    float timeBetweenEnemies = 1f;
    float nextEnemyTime;

    // Start is called before the first frame update
    void Start()
    {
        stageTransform = GameObject.FindGameObjectWithTag("Stage").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextEnemyTime < Time.time){
            nextEnemyTime += timeBetweenEnemies;
            SpawnEnemy();
        }
    }

    void SpawnEnemy(){
        float halfPlaneLength = 5;
        float halfEnemyWidth = Enemy.transform.localScale.z / 2;
        Vector3 spawnPosition;
        spawnPosition.x = stageTransform.localScale.x * 2 * halfPlaneLength + 2;
        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-stageTransform.localScale.z * halfPlaneLength + halfEnemyWidth, stageTransform.localScale.z * halfPlaneLength - halfEnemyWidth);
        Instantiate(Enemy, spawnPosition, Quaternion.identity);
    }
}
