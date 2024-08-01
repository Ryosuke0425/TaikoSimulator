using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollBody : MonoBehaviour
{
    public float NoteSpeed = 13.334f;
    private float judgePosition = -8.0f;
    bool used = false;
    //public int objectID;


      void Update()
    {
        if(GameManager.instance.start){
            transform.position += transform.forward * Time.deltaTime * NoteSpeed;           
        }
        if(transform.position.x <= judgePosition && !used){
            used = true;
        }
        if(transform.position.x <= -9 && used && !RollManager.instance.roll){
            Destroy(this.gameObject);
        }


        //if(transform.position.x <= -10 && RollManager.instance.rollEnd){
        //    Destroy(this.gameObject);
        //}

    }
}
