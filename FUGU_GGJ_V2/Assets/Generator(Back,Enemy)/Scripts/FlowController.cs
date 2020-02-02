using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{

    //Attach this for flow Objects. 
    public float speed;

    public float deletePosition;

    GenerateController generater;

    void Start()
    {
        //speed = speed * Random.value; 
        generater = GameObject.Find("GenerateController").GetComponent<GenerateController>();
   
    }

    
    void FixedUpdate()
    {
        this.speed = generater.Speed;
        transform.Translate(0,0, speed);

        if(transform.position.z <= deletePosition){
            //Hyahaaaの顔呼び出し
            if(this.gameObject.name.Equals("GenerateHyahaa(Clone)")){
                if(this.transform.position.x <= 0){
                   GameObject.Find("BlindController").GetComponent<BlindController>().IsLeftBlind = true;
                }else{
                   GameObject.Find("BlindController").GetComponent<BlindController>().IsRightBlind = true;
                }
            }

            Destroy(gameObject);
        }
    }
}
