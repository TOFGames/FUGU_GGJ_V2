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

    /*[SerializeField]
    private float speed;
*/

    public float startTime;
    public float generateTime;

    public GameObject[] prefabs; 

    ParameterManager para;
   
    void Start()
    {
        para = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
        InvokeRepeating ("GenerateObjects", startTime, generateTime);//forTest
    }


    void FixedUpdate()
    {
        
    }

    public void GenerateObjects(){
        //if(gameStart){}

        //for manyPrefabs to random
         int i = Random.Range(0, prefabs.Length);

         if(prefabs.Length >= 2){

            if(para.Score >= 30 && para.Score < 50){//Ended World
                i = Random.Range(0, 1);
            }else if(50 <= para.Score && para.Score < 70){//Danger
                i = Random.Range(2, 3);
            }else if(70 <= para.Score){//Safety
                //i = Random.Range(4, 5);
                i = 4;
            }

            if(para.Score >= 30){
                GameObject obj=Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ), Quaternion.identity) as GameObject;
            }

         }else{
            GameObject obj=Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ), Quaternion.identity) as GameObject;
         }

         
         //obj.transform.eulerAngles=new Vector3(0,180,0);
         //obj.GetComponent<BackFlowController>().speed = para.BackgroundSpeed;
         //Instantiate(prefabs[i], new Vector3(Random.Range(leftX, rightX), this.transform.position.y, frontZ));

         //int i = Random.Range(0, prefabs.Length);
         //int pos_x = Random.Range(leftX, rightX);
         //int pos_z = Random.Range(TopZ, bottomZ);
         //Instantiate(prefabs[i], new Vector3(pos_x, this.transform.position.y, pos_Z), Quaternion.identity);

        
    }
}
