using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour
{

    public AudioSource audioSource;

    public IEnumerator FadeOut(float duration) {
    float startVolume = audioSource.volume;

        while (audioSource.volume > 0){
            audioSource.volume -= startVolume * Time.deltaTime / duration;
            yield return null;
        }

    audioSource.Stop();
    audioSource.volume = startVolume;
}


    //// Start is called before the first frame update
    //void Start()
    //{
    //    
    //}
//
    //// Update is called once per frame
    //void Update()
    //{
    //    
    //}
}
