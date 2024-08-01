using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public SongDataBase dataBase;
    AudioSource song;
    AudioClip Music;
    string songName;
    bool played;
    void Start()
    {
        songName = dataBase.songData[GameManager.instance.songID].songName;
        song = GetComponent<AudioSource>();
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        Debug.Log(songName);
        played = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !played){
            played = true;
            song.PlayOneShot(Music);
        }    
    }
}
