using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int songID;
    public int combo = 0;
    public int perfect = 0;
    public int good = 0;
    public int miss = 0;
    public int roll = 0;
    private bool noteExist;
    public int noteCount = 0;
    public bool start = false;
    public bool autoPlay = false;


    public void Awake(){
        if(instance==null){
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
