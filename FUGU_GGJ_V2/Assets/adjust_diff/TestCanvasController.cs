using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCanvasController : MonoBehaviour
{

    public Text scoreText;
    ParameterManager pra;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("scoreTest").GetComponent<Text>();
        pra = GameObject.Find("ParameterManager").GetComponent<ParameterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "peace and order:"+(pra.Score).ToString();
    }
}
