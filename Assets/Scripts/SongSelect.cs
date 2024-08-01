using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SongSelect : MonoBehaviour
{
    public SongDataBase dataBase;
    public TextMeshProUGUI[] songNameText;
    public TextMeshProUGUI[] songLevelText;

    AudioSource audio;
    AudioClip Music;
    string songName;
    int select;


    void Start()
    {
        //select = 0;
        audio = GetComponent<AudioSource>();
        songName = dataBase.songData[select].songName;
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        SongUpdateALL();   
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(select < dataBase.songData.Length - 1){
                select++;
                SongUpdateALL();
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(select > 0){
                select--;
                SongUpdateALL();
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            SongStart();
        }
    }

    private void SongUpdateALL(){
        songName = dataBase.songData[select].songName;
        Music = (AudioClip)Resources.Load("Musics/" + songName);
        audio.Stop();
        audio.PlayOneShot(Music);
        for(int i = 0 ;i < 5;i++){
            SongUpdate(i-2);
        }
    }
    private void SongUpdate(int id){
        try{
            songNameText[id + 2].text = dataBase.songData[select + id].songName;
            songLevelText[id + 2].text = "Lv." + dataBase.songData[select + id].songLevel;
        }
        catch{
            songNameText[id + 2].text = "";
            songLevelText[id + 2].text = "";
        }
    }
    private void SongStart(){
        GameManager.instance.songID = select;
        SceneManager.LoadScene("MusicScene");
    }
}
