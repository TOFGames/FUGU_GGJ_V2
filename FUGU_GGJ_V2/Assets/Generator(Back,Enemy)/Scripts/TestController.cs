using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(Input.GetKey(KeyCode.RightArrow)){//右

            transform.Translate(0,0,0.1f);
       
       }else if(Input.GetKey(KeyCode.LeftArrow)){//左
       
            transform.Translate(0,0,-0.1f);
       
       }else if(Input.GetKey(KeyCode.UpArrow)){//上

            transform.Translate(0,0.1f,0);
       
       }else if(Input.GetKey(KeyCode.DownArrow)){//下

            transform.Translate(0,-0.1f,0);

       }
    }
}
