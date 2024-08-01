using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollHead : MonoBehaviour
{

    public float NoteSpeed = 13.334f;
    private float judgePosition = -8.0f;
    bool used = false;
    public int objectID;


      void Update()
    {
        if(GameManager.instance.start){
            transform.position += transform.forward * Time.deltaTime * NoteSpeed;           
        }



        if(transform.position.x <= judgePosition && !used){
            GameManager.instance.noteCount += 1;
            RollManager.instance.roll = true;
            used = true;
        }
        if(transform.position.x <= -10 && used){
            Destroy(this.gameObject);
        }

    }
  


}
