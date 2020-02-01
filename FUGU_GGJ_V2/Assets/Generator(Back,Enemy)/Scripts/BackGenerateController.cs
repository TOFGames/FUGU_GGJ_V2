using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGenerateController : MonoBehaviour
{

    //To generrate something.

    public float leftX = 0.0f;
    public float rightX = 0.0f;
    public float frontZ = 0.0f;
    //public float TopZ;
    //pbulic float bottomZ;

    [SerializeField]
    private float speed;

    public float startTime;
    public float generateTime;

    public GameObject[] prefabs; 

   
    void Start()
    {
        InvokeRepeating ("GenerateObjects", startTime, generateTime);//forTest
    }


    void FixedUpdate()
    {
        
    }

    public void GenerateObjects(){
        //if(gameStart){}

        //for manyPrefabs to random
         int i = Random.Range(0, prefabs.Length);
         GameObject obj=Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ), Quaternion.identity) as GameObject;
         //obj.transform.eulerAngles=new Vector3(0,180,0);
         obj.GetComponent<FlowController>().speed = this.speed;
         //Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ));

         //int i = Random.Range(0, prefabs.Length);
         //int pos_x = Random.Range(leftX, rightX);
         //int pos_z = Random.Range(TopZ, bottomZ);
         //Instantiate(prefabs[i], new Vector3(pos_x, this.transform.position.y, pos_Z), Quaternion.identity);

        
    }
}
