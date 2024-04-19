using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ArrowMovement : MonoBehaviour
{

    public float speed;
    private Vector2 _speedVector2;
    private ArrowSpawnScript _arrowSpawnScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _arrowSpawnScript = FindObjectOfType<ArrowSpawnScript>();
        _speedVector2 = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _speedVector2 += new Vector2(0, speed*Time.deltaTime);
        transform.position = _speedVector2;
        if(transform.position.y > _arrowSpawnScript.screenHeight)
        {
            GameObject.Destroy(this.gameObject);
        }
    }


}
