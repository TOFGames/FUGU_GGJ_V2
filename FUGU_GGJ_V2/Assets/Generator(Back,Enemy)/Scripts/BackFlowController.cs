using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFlowController : MonoBehaviour
{

    //Attach this for flow Objects. 
    //public float speed{ get; set;}
    public float speed;

    public float deletePosition;

    ParameterManager para;

    void Start()
    {
        //speed = speed * Random.value; 
        para = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
    }

    
    void FixedUpdate()
    {
        this.speed = para.BackgroundSpeed;
        transform.Translate(0,0, -speed);

        if(transform.position.z <= deletePosition){
            Destroy(gameObject);
        }
    }
}
