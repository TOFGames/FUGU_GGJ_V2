using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvasController : MonoBehaviour
{

    public Text scoreText;
    ParameterManager para;
    string peaceExpression;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        para = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = "peace and order:"+(pra.Score).ToString();

       // if(pre.Score )

        //int score = para.Score;

        if(para.Score < 30){//Ended World
          peaceExpression = "Ended World";
        }else if(30 <= para.Score && para.Score < 50) {//MAD MAX
          peaceExpression = "MAD MAX";
        }else if(50 <= para.Score && para.Score < 70){//Danger
          peaceExpression = "Danger";
        }else if(70 <= para.Score && para.Score < 85){//Safety
          peaceExpression = "Safety";
        }else{//Peaceful
          peaceExpression = "Peaceful";
        }
        scoreText.text = "World State:"+peaceExpression;
    }
}
