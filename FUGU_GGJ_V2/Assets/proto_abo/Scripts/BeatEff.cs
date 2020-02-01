using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AboProto {
    public class BeatEff : MonoBehaviour {
        private Image slashImage;
        private RectTransform slashRect;
        private Text seiText;
        private Text baiText;

        private Vector2 startSize = new Vector2(3000,900);
        private Vector2 goalSize = new Vector2(3000,10);
        Color slashStartColor;
        Color textStartColor;

        //=============================================================
        private void Init () {
            slashImage = transform.Find("Slash").GetComponent<Image>();
            slashRect = transform.Find("Slash").GetComponent<RectTransform>();
            seiText = transform.Find("Sei").GetComponent<Text>();
            baiText = transform.Find("Bai").GetComponent<Text>();
        }

        private void Awake () {
            Init();
        }

        /*private void Start () {
            StartCoroutine(Slash(5,5,2));
        }*/

        private void OnEnable () {
            StartCoroutine(Slash(5,5,2));
        }

        /// <summary>
        /// スラッシュエフェクト
        /// </summary>
        private IEnumerator Slash (float spd1,float spd2,float spd3) {
            AudioManager.Instance.PlaySE("slash");

            float time = 0;
            while(true) {
                time += Time.deltaTime * spd1;
                if(time >= 1.01f) {
                    time = 0;

                    slashRect.sizeDelta = goalSize;
                    slashRect.eulerAngles = Vector3.forward * 90;
                    break;
                }

                slashRect.sizeDelta = Vector2.Lerp(startSize,goalSize,time);
                slashRect.eulerAngles = Vector3.Lerp(Vector3.zero,Vector3.forward * 90,time);

                yield return null;
            }

            slashStartColor = slashImage.color;
            while(true) {
                time += Time.deltaTime * spd2;
                if(time >= 1.01f) {
                    time = 0;

                    slashImage.color = new Color(slashStartColor.r,slashStartColor.g,slashStartColor.b,0);
                    break;
                }

                slashImage.color = new Color(slashStartColor.r,slashStartColor.g,slashStartColor.b,1 - time);

                yield return null;
            }

            textStartColor = seiText.color;
            while(true) {
                time += Time.deltaTime * spd3;
                if(time >= 1.01f) {
                    time = 0;

                    seiText.color = new Color(textStartColor.r,textStartColor.g,textStartColor.b,0);
                    baiText.color = new Color(textStartColor.r,textStartColor.g,textStartColor.b,0);
                    break;
                }

                seiText.color = new Color(textStartColor.r,textStartColor.g,textStartColor.b,1 - time);
                baiText.color = new Color(textStartColor.r,textStartColor.g,textStartColor.b,1 - time);

                yield return null;
            }

            slashRect.sizeDelta = startSize;
            slashRect.eulerAngles = Vector3.zero;
            slashImage.color = slashStartColor;
            seiText.color = textStartColor;
            baiText.color = textStartColor;
            gameObject.SetActive(false);
            yield return null;
        }
    }
}