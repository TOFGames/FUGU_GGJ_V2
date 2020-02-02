using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateController : MonoBehaviour {

    //To generrate something.

    public float leftX = 0.0f;
    public float rightX = 0.0f;
    public float frontZ = 0.0f;
    //public float TopZ;
    //pbulic float bottomZ;

    [SerializeField]
    private float speed;

    public float Speed {
        get { return speed; }
        set { speed = value; }
    }

    public float startTime;
    public float generateTime;

    public GameObject[] prefabs;

    ParameterManager para;

    private GameManager gameManager;

    float distance = 0.0f;

    void Start () {
        para = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
        //InvokeRepeating ("GenerateObjects", startTime, generateTime);//forTest
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void FixedUpdate () {
        if(!gameManager.EndedGame) {
            this.speed = para.BackgroundSpeed;
            distance += speed;
            if(distance >= 25.0f) {
                GenerateObjects();
                distance = 0.0f;
            }
        }
    }

    public void GenerateObjects () {
        //if(gameStart){}

        //for manyPrefabs to random



        float rand = Random.Range(0.0f,1.0f);
        float border = 0.5f;

        int score = para.Score;

        if(score < 30) {//Enden World
            border = 0.0f;
        } else if(30 <= score && score < 50) {//MAD MAX
            border = 0.3f;
        } else if(50 <= score && score < 70) {//Danger
            border = 0.5f;
        } else if(70 <= score && score < 85) {//Safety
            border = 0.7f;
        } else {//Peaceful
            border = 0.85f;
        }




        //border = score / 100; //0.3とかMaxわからないと何ともか?


        //int i = Random.Range(0, prefabs.Length);

        int i;

        if(rand >= border) {
            i = 0;//Hyahaaaa
        } else {
            i = 1;//NomalMan
        }


        GameObject obj = Instantiate(prefabs[i],new Vector3(Random.Range(leftX,rightX),this.transform.position.y,frontZ),Quaternion.identity) as GameObject;
        obj.transform.eulerAngles = new Vector3(0,180,0);

    }
}
