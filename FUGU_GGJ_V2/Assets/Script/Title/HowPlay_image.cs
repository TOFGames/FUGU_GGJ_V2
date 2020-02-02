using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowPlay_image : MonoBehaviour
{
        private float canvas_sizeX;//上下の大きさ取得
        private float canvas_sizeY;
        void Start()
        {
                canvas_sizeX=Screen.width;
                canvas_sizeY=Screen.height;
                this.transform.localScale = new Vector3(canvas_sizeX, canvas_sizeY, 1);
        }
        public void Click(){
                this.gameObject.SetActive (false);
        }
}
