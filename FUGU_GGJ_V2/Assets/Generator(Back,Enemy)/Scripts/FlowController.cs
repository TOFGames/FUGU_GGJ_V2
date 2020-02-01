using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{

    //Attach this for flow Objects. 

    public float speed;

    public float deletePosition;

    
    void Start()
    {
        //speed = speed * Random.value; 
    }

    
    void FixedUpdate()
    {
        transform.Translate(0,0,-speed);

        if(transform.position.z <= deletePosition){
            Destroy(gameObject);
        }
    }
}
