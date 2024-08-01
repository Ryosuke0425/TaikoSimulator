using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MusicScene : MonoBehaviour
{
    public GameObject finish;
    public TextMeshProUGUI comboText;
    private bool noteExist;

    void OnEnable(){
        GameManager.instance.start = false;
    }
    void Update(){
        CheckKey();
        comboText.text = GameManager.instance.combo.ToString();
        noteExist = (GameObject.Find("Don(Clone)") != null) || (GameObject.Find("Ka(Clone)") != null);
        if(!noteExist){
            finish.SetActive(true);
            Invoke("ResultScene",3f);
            return;
        }
    }
    void ResultScene(){
        SceneManager.LoadScene("Result");
    }
    void CheckKey(){
        if(Input.GetKeyDown(KeyCode.Space)){
            GameManager.instance.start = true;
        }
        if(Input.GetKeyDown(KeyCode.F1)){
            GameManager.instance.autoPlay = !GameManager.instance.autoPlay;
        }
    }
}
