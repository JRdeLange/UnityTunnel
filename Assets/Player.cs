using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject bullet;
    float speed = 5;
    string fireAxis = "Fire1";
    string moveAxis = "Horizontal";
    Transform stageTransform;
    int points;

    // Start is called before the first frame update
    void Start()
    {
        stageTransform = GameObject.FindGameObjectWithTag("Stage").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        Fire();
        
    }

    void Fire(){
        if (Input.GetButtonDown(fireAxis)){
            Vector3 spawnPoint = transform.position;
            Instantiate(bullet, spawnPoint, Quaternion.identity);
        }
    }

    void Move(){
        Vector3 input = new Vector3(Input.GetAxisRaw(moveAxis), 0, 0);
        Vector3 movement = input * speed * Time.deltaTime;
        transform.Translate(movement);
        float playerWidth = transform.localScale.x / 2;
        float halfPlaneLength = 5;
        if (transform.position.z > stageTransform.localScale.z * halfPlaneLength - playerWidth){
            transform.position = new Vector3(transform.position.x, transform.position.y, stageTransform.localScale.z * halfPlaneLength - playerWidth);
        } else if (transform.position.z < -stageTransform.localScale.z * halfPlaneLength + playerWidth){
            transform.position = new Vector3(transform.position.x, transform.position.y, -stageTransform.localScale.z * halfPlaneLength + playerWidth);
        }
    }

    public void addPoints(int amount){
        points += amount;
        print("Points: " + points);
    }
}
