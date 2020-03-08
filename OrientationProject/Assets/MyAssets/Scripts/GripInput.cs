using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GripInput : MonoBehaviour
{

    private float fadeDuration = 1f;
    public SteamVR_Input_Sources handType; // 1
    public SteamVR_Action_Boolean grabAction; // 3
    public bool GetGrab() // 2
    {
        return grabAction.GetState(handType);
    }

    void Update()
    {
        if (GetGrab())
        {
            print("Grab " + handType);
            FadeToBlack();
            StartCoroutine("waitAndEndGame");
        }
    }
     IEnumerator waitAndEndGame()
        {
             //wait for fade to finish
            yield return new WaitForSeconds(fadeDuration + 3);
            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;
            
        }
     private void FadeToBlack()
        {
            //set start color
            SteamVR_Fade.Start(Color.clear, 0f);
            //set and start fade to
            SteamVR_Fade.Start(Color.black, fadeDuration);
        }
}