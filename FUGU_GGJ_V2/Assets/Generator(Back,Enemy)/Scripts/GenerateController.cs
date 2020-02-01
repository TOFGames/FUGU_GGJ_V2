using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateController : MonoBehaviour
{

    //To generrate something.

    public float leftX = 0.0f;
    public float rightX = 0.0f;
    public float frontZ = 0.0f;
    //public float TopZ;
    //pbulic float bottomZ;

    [SerializeField]
    private float speed;

    public float Speed{
        get { return speed; }
        set { speed = value;}
    }

    public float startTime;
    public float generateTime;

    public GameObject[] prefabs; 

    ParameterManager para;

    float distance = 0.0f;
   
    void Start()
    {
        para = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
        //InvokeRepeating ("GenerateObjects", startTime, generateTime);//forTest
    }


    void FixedUpdate()
    {
        this.speed = para.BackgroundSpeed;
        distance += speed;
        if( distance >= 25.0f){
            GenerateObjects();
            distance = 0.0f;
        }
    }

    public void GenerateObjects(){
        //if(gameStart){}

        //for manyPrefabs to random

        /*

        if(score < 30){//Enden World

        }else if(30 <= socre && score < 50) {//MAD MAX
        
        }else if(50 <= socre && score < 70){//Danger

        }else if(70 <= socre && score < 85){//Safety

        }else{//Peaceful

        }

        */

        float rand = Random.Range(0.0f, 1.0f);
        float border = 0.5f;
        //border = score / 100; //0.3とかMaxわからないと何ともか?


         //int i = Random.Range(0, prefabs.Length);

         int i;

         if( rand <= border ){
             i = 0;//Hyahaaaa
         }else{
             i = 1;//NomalMan
         }


         GameObject obj=Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ), Quaternion.identity) as GameObject;
         obj.transform.eulerAngles=new Vector3(0,180,0);
        // obj.GetComponent<FlowController>().speed = this.speed;
         //Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ));

         //int i = Random.Range(0, prefabs.Length);
         //int pos_x = Random.Range(leftX, rightX);
         //int pos_z = Random.Range(TopZ, bottomZ);
         //Instantiate(prefabs[i], new Vector3(pos_x, this.transform.position.y, pos_Z), Quaternion.identity);

        
    }
}
