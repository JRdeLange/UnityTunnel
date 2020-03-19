using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{

    Renderer rend;
    float scrollSpeed;
    Constants constants;


    // Start is called before the first frame update
    void Start()
    {
       rend = GetComponent<Renderer>();
       constants = GameObject.FindGameObjectWithTag("Constants").GetComponent<Constants>();
       scrollSpeed = constants.getEnemySpeed() / 5;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        offset = offset % 1;
        rend.material.SetTextureOffset("_MainTex", Vector2.left * offset);
    }
}
