using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadText : MonoBehaviour
{
    public SongDataBase dataBase;
    private string songName;
    public string[] textMessage;
    float startPosition;// = -39.0f;
    float noteSpeedDefault = 13.335f;
    float bpm = 200.0f;
    float hs = 1.0f;
    float perfectRangeDefault = 0.5f;
    float goodRangeDefault = 0.65f;
    float badRangeDefault = 0.67f;
    public float beforeBPM;
    public float startPlus = 0;
    
    public int count = 0;
    public int countMeasure;
    public float countAll = 0;
    bool roll = false;
    float rollHeadPos;
    float rollEndPos;
    float interval;
    void OnEnable()
    {
        songName = dataBase.songData[GameManager.instance.songID].songName;
        startPosition = dataBase.songData[GameManager.instance.songID].startPosition;
        bpm = dataBase.songData[GameManager.instance.songID].bpm;
        GameManager.instance.noteCount = 0;
        TextAsset textasset = new TextAsset();
        textasset = Resources.Load("Sheet/" + songName,typeof(TextAsset)) as TextAsset;
        string textLines = textasset.text;
        textMessage = textLines.Split(",");

        for(int i = 0;i<textMessage.Length;i++){
            //count = 0;
            string[] textMessageLines = textMessage[i].Split("\n");
            interval = Interval(textMessageLines);
            for(int j = 0;j < textMessageLines.Length;j++){
                            
                if(textMessageLines[j] == ""){
                    continue;
                }
                if(textMessageLines[j].Contains("BPM:")){
                    beforeBPM = bpm;
                    bpm = float.Parse(textMessageLines[j].Split("BPM:")[1]);
                    //startPlus = (countAll + 1) * bpm / beforeBPM - 1;
                    startPlus += countAll;
                    startPlus = (startPlus + 1) * bpm / beforeBPM - 1;
                    startPlus -= countAll;
                    
                    Debug.Log(startPlus);
                    continue;
                }
                if(textMessageLines[j].Contains("HS:")){
                    hs = float.Parse(textMessageLines[j].Split("HS:")[1]);
                    continue;
                }
                PutNote(textMessageLines[j]);
            }
            countMeasure += 1;

        }

    }

    public void PutNote(string textMessageLine){

        for(int i = 0; i < textMessageLine.Length;i++){
            
            if(textMessageLine[i] == '1'){
                GameObject obj = (GameObject)Resources.Load("Don");
                obj.GetComponent<Don>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                obj.GetComponent<Don>().perfectRange = perfectRangeDefault * obj.GetComponent<Don>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Don>().goodRange = goodRangeDefault * obj.GetComponent<Don>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Don>().badRange = badRangeDefault * obj.GetComponent<Don>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Don>().objectID = count;

                //Instantiate(obj,new Vector3(startPosition + (16 * ((countMeasure + 1) * hs - 1) + count),90.0f - 0.1f * countAll,0.0f),Quaternion.Euler(0,-90,0));
                //Instantiate(obj,new Vector3(startPosition + startPlus + (countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '3'){
                GameObject obj = (GameObject)Resources.Load("BigDon");
                obj.GetComponent<Don>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                obj.GetComponent<Don>().perfectRange = perfectRangeDefault * obj.GetComponent<Don>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Don>().goodRange = goodRangeDefault * obj.GetComponent<Don>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Don>().badRange = badRangeDefault * obj.GetComponent<Don>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Don>().objectID = count;
                Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '2'){
                GameObject obj = (GameObject)Resources.Load("Ka");
                obj.GetComponent<Ka>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                obj.GetComponent<Ka>().perfectRange = perfectRangeDefault * obj.GetComponent<Ka>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Ka>().goodRange = goodRangeDefault * obj.GetComponent<Ka>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Ka>().badRange = badRangeDefault * obj.GetComponent<Ka>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Ka>().objectID = count;

                Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '4'){
                GameObject obj = (GameObject)Resources.Load("BigKa");
                obj.GetComponent<Ka>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                obj.GetComponent<Ka>().perfectRange = perfectRangeDefault * obj.GetComponent<Ka>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Ka>().goodRange = goodRangeDefault * obj.GetComponent<Ka>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Ka>().badRange = badRangeDefault * obj.GetComponent<Ka>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Ka>().objectID = count;

                Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '5'){
                GameObject obj = (GameObject)Resources.Load("RollHead");
                obj.GetComponent<RollHead>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
               obj.GetComponent<RollHead>().objectID = count;
                Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                roll = true;
                rollHeadPos = startPosition + (startPlus + countAll + 1) * hs - 1;
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '7'){
                GameObject obj = (GameObject)Resources.Load("Balloon");
                obj.GetComponent<Balloon>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
               obj.GetComponent<Balloon>().perfectRange = perfectRangeDefault * obj.GetComponent<Balloon>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Balloon>().goodRange = goodRangeDefault * obj.GetComponent<Balloon>().NoteSpeed / noteSpeedDefault;
                obj.GetComponent<Balloon>().badRange = badRangeDefault * obj.GetComponent<Balloon>().NoteSpeed / noteSpeedDefault;
               obj.GetComponent<Balloon>().objectID = count;
                Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '8'){
                if(roll){
                    GameObject obj = (GameObject)Resources.Load("RollEnd");
                    obj.GetComponent<RollEnd>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                    obj.GetComponent<RollEnd>().objectID = count;
                    Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                    roll = false;
                    rollEndPos = startPosition + (startPlus + countAll + 1) * hs - 1;
                    GameObject rollObj = (GameObject)Resources.Load("RollBody");
                    rollObj.GetComponent<RollBody>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                    rollObj.transform.localScale = new Vector3(1.0f,1.0f,rollEndPos - rollHeadPos - 1.0f);
                    Instantiate(rollObj,new Vector3((rollHeadPos + rollEndPos) / 2.0f,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));

                }else{
                    GameObject obj = (GameObject)Resources.Load("BalloonEnd");
                    obj.GetComponent<BalloonEnd>().NoteSpeed = noteSpeedDefault * hs * bpm / 200.0f;
                    obj.GetComponent<BalloonEnd>().objectID = count;
                    Instantiate(obj,new Vector3(startPosition + (startPlus + countAll + 1) * hs - 1 ,90.0f - 0.1f * count,0.0f),Quaternion.Euler(0,-90,0));
                }
                count += 1;
                countAll += interval;
            }else if(textMessageLine[i] == '0'){
                countAll += interval;
                
            }else{
                continue;
            }
        }

    }
    float Interval(string[] measure){
        float result = 0;
        for(int j = 0;j < measure.Length;j++){
            if(measure[j].Contains("BPM:") || measure[j].Contains("HS:")){
                continue;
            }else{
                result += measure[j].Trim().Length;
            }
        }
        if(result == 0){
            return 0;
        }
        return 16 / result;
    }

}
