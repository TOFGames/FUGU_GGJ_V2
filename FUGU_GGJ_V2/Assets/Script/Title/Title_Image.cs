using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Title_Image : MonoBehaviour
{
        Image image_component;
        private float canvas_sizeX;//上下の大きさ取得
        private float canvas_sizeY;
        float title_color=0.0f;//タイトルを黒くする
        public float title_clear=0.0f;//タイトルを透明化
        public static bool Blackout=false;
        void Start()
        {
                image_component = GetComponent<Image>();
                canvas_sizeX=Screen.width;
                canvas_sizeY=Screen.height;
                this.transform.localScale = new Vector3(0, 0, 1);
                title_clear=0.0f;
                Blackout=false;
        }

        void Update()
        {
                if(title_clear<1&&Blackout==true) {
                        this.transform.localScale = new Vector3(canvas_sizeX, canvas_sizeY, 1);
                        title_clear+=0.01f;
                        //Blackout=true;
                }
                image_component.color=new Color(title_color,title_color,title_color,title_clear);
                if(title_clear>1) {
                        SceneManagement.SceneSwich=1;
                }
        }
}
