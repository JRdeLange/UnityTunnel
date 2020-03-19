using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Constants constants;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
       constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (transform.position.x < -5){
            Destroy(gameObject);
        }
    }

    void Move(){
        float speed = constants.getEnemySpeed();
        Vector3 movement = Vector3.left * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    void OnTriggerEnter(Collider collider){
        print(collider.tag);
        if (collider.tag == "Bullet"){
            player.addPoints(1);
            Destroy(gameObject);
        }
    }
}
