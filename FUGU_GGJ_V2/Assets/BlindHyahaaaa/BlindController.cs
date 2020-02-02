using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BlindController : MonoBehaviour
{

        private bool isLeftBlind = false;

        public bool IsLeftBlind {
                get{ return isLeftBlind; }
                set{ isLeftBlind = value; }
        }

        public bool movingLeft = false;

        private bool isRightBlind = false;

        public bool IsRightBlind {
                get{ return isRightBlind; }
                set{ isRightBlind = value; }
        }

        public bool movingRight = false;

        public GameObject leftHyahaaa;
        //Vector3 leftVec3;

        public GameObject rightHyahaa;
        //Vector3 rightVec3;

        public float blindTime;

        void Start()
        {
                //leftVec3 = leftHyahaaa.transform.position;
                //rightVec3 = rightHyahaa.transform.position;

                leftHyahaaa.SetActive(false);
                rightHyahaa.SetActive(false);
        }


        void FixedUpdate()
        {
                if(isLeftBlind == true && movingLeft == false) {//バグる
                        isLeftBlind = false;
                        movingLeft = true;
                        StartCoroutine(GoBlindLeft(leftHyahaaa));
                }

                if(isRightBlind == true && movingRight  == false) {
                        isRightBlind = false;
                        movingRight = true;
                        StartCoroutine(GoBlindRight(rightHyahaa));
                }
        }

        public IEnumerator GoBlindLeft(GameObject blind){

                // moving = true;

                blind.SetActive(true);

                //before -1.86, -0.21, -0.6
                //after  -1.53,  0.56, -0.6
                //diff    0.33,  0.77



                for(int i=0; i< blindTime; i++) {
                        //moveHyahaaa.gameObject.transform.Translate(0.01f/Bli, 0.03f/60.0f, 0.01f/60.0f);
                        blind.transform.Translate(new Vector3(0.33f, 0.77f, 0.0f) / blindTime);

                        yield return null;
                }

                yield return new WaitForSeconds(0.5f);

                //Voice「ヒャッはあああああああああああああ！！！！！」
                AboProto.AudioManager.Instance.PlaySE("hyaaa");

                for(int i=0; i< blindTime; i++) {
                        //moveHyahaaa.gameObject.transform.Translate(-0.01f/60.0f, -0.03f/60.0f, -0.01f/60.0f);
                        blind.transform.Translate(new Vector3(-0.33f, -0.77f, 0.0f) / blindTime);

                        yield return null;
                }

                movingLeft = false;
                blind.SetActive(false);

                yield return null;
        }


        public IEnumerator GoBlindRight(GameObject blind){

                // moving = true;

                blind.SetActive(true);

                //before -1.86, -0.21, -0.6
                //after  -1.53,  0.56, -0.6
                //diff    0.33,  0.77

                for(int i=0; i< blindTime; i++) {
                        //moveHyahaaa.gameObject.transform.Translate(0.01f/Bli, 0.03f/60.0f, 0.01f/60.0f);
                        blind.transform.Translate(new Vector3(0.33f, 0.77f, 0.0f) / blindTime);

                        yield return null;
                }

                yield return new WaitForSeconds(0.5f);

                //Voice「ヒャッはあああああああああああああ！！！！！」
                AboProto.AudioManager.Instance.PlaySE("hyaaa");

                for(int i=0; i< blindTime; i++) {
                        //moveHyahaaa.gameObject.transform.Translate(-0.01f/60.0f, -0.03f/60.0f, -0.01f/60.0f);
                        blind.transform.Translate(new Vector3(-0.33f, -0.77f, 0.0f) / blindTime);

                        yield return null;
                }

                movingRight = false;
                blind.SetActive(false);

                yield return null;
        }
}
