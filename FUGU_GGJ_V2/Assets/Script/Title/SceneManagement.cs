using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagement : MonoBehaviour
{
        public static int SceneSwich=0;
        void Start()
        {
                SceneSwich=0;
        }

        void Update()
        {
                if(SceneSwich!=0) {//Mswichを変えるだけで特定の動作をする
                        SceneSW(SceneSwich);
                }
        }
        void SceneSW(int swich){
                if(swich==1) {
                        SceneManager.LoadScene ("AbosWork");
                }
        }
}
