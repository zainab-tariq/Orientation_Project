using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
        //-------------------------------------------------------------------------
        [RequireComponent(typeof(Interactable))]
    public class LoadScene : MonoBehaviour
    {
        private GameObject objectNotToBeDestroyed;

        void Awake(){
            objectNotToBeDestroyed = GameObject.Find("Teleporting");
            DontDestroyOnLoad(objectNotToBeDestroyed);
        }
        private float fadeDuration = 1f;

        private void HandHoverUpdate(Hand hand)
            {
               GrabTypes startingGrabType = hand.GetGrabStarting();
               if(startingGrabType != GrabTypes.None)
               {
                   FadeToBlack();
                   StartCoroutine("waitAndFade"); 
                   StartCoroutine("waitAndLoadScene");
               }
               
            }
            
            IEnumerator waitAndFade()
            {
                yield return new WaitForSeconds(3);
                FadeFromBlack();

            }
             IEnumerator waitAndLoadScene()
            {
                yield return new WaitForSeconds(3);
                SceneManager.LoadScene("MyAssets/Scenes/Warehouse"); 

            }

    	private void FadeToBlack()
        {
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.black, fadeDuration);
        }

        private void FadeFromBlack()
        {
            //set start color
            SteamVR_Fade.Start(Color.black, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.clear, fadeDuration);
        }

    }
}