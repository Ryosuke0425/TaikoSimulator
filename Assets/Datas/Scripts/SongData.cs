using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SongData",menuName="楽曲データを作成")]

public class SongData : ScriptableObject
{
    public string songID;
    public string songName;
    public int songLevel;
    public float startPosition;
    public float bpm;
}
