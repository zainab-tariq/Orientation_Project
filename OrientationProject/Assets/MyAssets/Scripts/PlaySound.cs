using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource _audio;
    // Start is called before the first frame update
    void Start()
    {
        _audio = this.GetComponent<AudioSource>();
        if(_audio != null)
            _audio.Play();
    }
}
