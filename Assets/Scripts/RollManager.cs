using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RollManager : MonoBehaviour
{
    public static RollManager instance = null;
    public int rollCount = 0;
    public  bool roll = false;
    public TextMeshProUGUI rollText;

    void Awake(){
        instance = this;
    }

    void Update()
    {
        if(roll){
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J)){
                rollCount += 1;
                rollText.text = rollCount.ToString();
                //rollText.SetActive(true);
                Debug.Log(rollCount);
            }
        }
    }
}
