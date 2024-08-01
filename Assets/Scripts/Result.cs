using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI perfectText;
    public TextMeshProUGUI goodText;
    public TextMeshProUGUI missText;

    public void OnEnable()
    {
        perfectText.text = GameManager.instance.perfect.ToString();
        goodText.text = GameManager.instance.good.ToString();
        missText.text = GameManager.instance.miss.ToString();

        
    }


    public void Retry()
    {
        GameManager.instance.perfect = 0;
        GameManager.instance.good = 0;
        GameManager.instance.miss = 0;
        GameManager.instance.combo = 0;
        SceneManager.LoadScene("MusicScene");
    }
    public void Close()
    {
        GameManager.instance.perfect = 0;
        GameManager.instance.good = 0;
        GameManager.instance.miss = 0;
        GameManager.instance.combo = 0;
        SceneManager.LoadScene("MusicSelect");
    }
}
