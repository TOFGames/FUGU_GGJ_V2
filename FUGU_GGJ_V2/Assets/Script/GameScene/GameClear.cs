using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClear : MonoBehaviour
{
        public GameObject Button;
        public GameObject Maneger;
        GameManager flag;
        void Start()
        {
                flag=Maneger.GetComponent<GameManager>();
        }

        void Update()
        {
                if(flag.EndedEndingPerform3==true) {
                        Button.gameObject.SetActive (true);
                }
        }
}
