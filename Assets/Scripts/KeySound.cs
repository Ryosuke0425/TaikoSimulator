using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySound : MonoBehaviour
{
    public static KeySound instance = null;
    AudioSource donAudio;
    public AudioClip donSound;
    AudioSource kaAudio;
    public AudioClip kaSound;
    AudioSource balloonAudio;
    public AudioClip balloonSound;

    void Start(){
        donAudio = GetComponent<AudioSource>();
        kaAudio = GetComponent<AudioSource>();
        balloonAudio = GetComponent<AudioSource>();
        instance = this;
    }
    void Update()
    {
        if(!GameManager.instance.autoPlay){
            if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J)){
                //donAudio.PlayOneShot(donSound);
                Don();
            }
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.K)){
                //kaAudio.PlayOneShot(kaSound);
                Ka();
            }
        }
    }

    public void BreakBalloon(){
        balloonAudio.PlayOneShot(balloonSound);
    }
    public void Don(){
        donAudio.PlayOneShot(donSound);
    }

    public void  Ka(){
        kaAudio.PlayOneShot(kaSound);
    }
}
