using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    float speed = 40;
    Transform stageTransform;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        stageTransform = GameObject.FindGameObjectWithTag("Stage").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.right * speed * Time.deltaTime;
        transform.Translate(movement);

        float endOfStage = stageTransform.localScale.x * 10;
        if (transform.position.x > endOfStage - 10){
            Destroy(gameObject);
        }
    }
/**
    void OnTriggerEnter(Collider collider){
        print(collider.tag);
        if (collider.tag == "Enemy"){
            player.addPoints(1);
            Destroy(collider);
        }
    }
    **/
}
