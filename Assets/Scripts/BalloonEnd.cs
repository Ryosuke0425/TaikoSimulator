using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonEnd : MonoBehaviour
{

    public float NoteSpeed = 13.334f;
    private float judgePosition = -8.0f;
    bool start;
    public int objectID;

      void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            start = true;
        }
        if(start){
                transform.position += transform.forward * Time.deltaTime * NoteSpeed;
        }

        if(transform.position.x <= judgePosition){
            GameManager.instance.noteCount += 1;
            Destroy(this.gameObject);
        }

    }
}
