﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFlowController : MonoBehaviour
{

    //Attach this for flow Objects. 
    public float speed{ get; set;}

    public float deletePosition;


    void Start()
    {
        //speed = speed * Random.value; 
     
    }

    
    void FixedUpdate()
    {
        
        transform.Translate(0,0, speed);

        if(transform.position.z <= deletePosition){
            Destroy(gameObject);
        }
    }
}
