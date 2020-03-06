using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StopAudio : MonoBehaviour
{
    public GameObject AnimatedGameObject;
    private AudioSource _audio;
    private AudioSource myAudio;
    void Start()
    {
        _audio = AnimatedGameObject.GetComponent<AudioSource>();
        myAudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_audio.isPlaying)
        {
            //Debug.Log("audio is playing");
            StartCoroutine(FadeOut(myAudio, 40f));
            //myAudio.Stop();
        }

    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
        public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        audioSource.Play();
        audioSource.volume = 0f;
        while (audioSource.volume < 1)
        {
            audioSource.volume += Time.deltaTime / FadeTime;
            yield return null;
        }
    }
    
}