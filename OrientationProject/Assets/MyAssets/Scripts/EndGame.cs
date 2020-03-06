using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem.Sample
{
    public class EndGame : MonoBehaviour
    {
        public GameObject canvas;
        private float fadeDuration = 1f;
        public float waitTillGameEnds = 10;
        public float waitTillTextAppears = 5;
        public int interactionNum;
        public int InteractionNumber
        {
            get { return interactionNum; }
            set
            {
                if (interactionNum == value) return;
                interactionNum = value;
                if (endGameEvent != null)
                    endGameEvent(interactionNum);
            }
        }

        public delegate void EndGameEvent(int val);
        public static event EndGameEvent endGameEvent;

        private void Start()
        {
            endGameEvent += OnInteractionMax;
        }


        public void OnInteractionMax(int val)
        {
            if(interactionNum == 6){
                Debug.Log("end game now!");
                StartCoroutine("waitTillAudioFinish");
            }
        }

        IEnumerator waitTillAudioFinish()
        {
            StartCoroutine("waitAndShowCanvas");
            yield return new WaitForSeconds(waitTillGameEnds);
            FadeToBlack();
            StartCoroutine("waitAndEndGame");
        }

        IEnumerator waitAndShowCanvas()
        {
            yield return new WaitForSeconds(waitTillTextAppears);
            canvas.SetActive(true);
        }
        IEnumerator waitAndEndGame()
        {
             //wait for fade to finish
            yield return new WaitForSeconds(fadeDuration + 3);
            //Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
            
        }
        private void FadeToBlack()
        {
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.black, fadeDuration);
        }
    }

}
