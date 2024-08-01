using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Don : MonoBehaviour
{

    public float NoteSpeed = 13.334f;
    public float perfectRange;
    public float goodRange;
    public float badRange;
    private float judgePosition = -8.0f;
    //bool start;
    public GameObject[] MessageObj;
    public int objectID = 0;
    //bool autoPlay = false;


    void Update()
    {


        if(GameManager.instance.start){
            transform.position += transform.forward * Time.deltaTime * NoteSpeed;
        }
        if(GameManager.instance.autoPlay){
            if(transform.position.x <= -8.0f){
                Judgement(this.transform.position.x);
                KeySound.instance.Don();
                DonLight.instance.ColorChange();
            }
            return;
        }
        if(objectID == GameManager.instance.noteCount){
        if((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))){
            //if(Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J)){
                //Debug.Log(GameManager.instance.noteCount);

                Judgement(this.transform.position.x);
            }
        }
        if(transform.position.x <= judgePosition - badRange){
           GameManager.instance.noteCount += 1;
           GameManager.instance.combo = 0;
           GameManager.instance.miss += 1;
           Destroy(this.gameObject);


        }

    }
  


    void Judgement(float positionX){
        if(judgePosition - perfectRange < positionX && positionX < judgePosition + perfectRange){
            //Debug.Log("Good");
            Message(0);
            GameManager.instance.combo += 1;
            GameManager.instance.perfect += 1;
            GameManager.instance.noteCount += 1;            
            Destroy(this.gameObject);

        }else if(judgePosition - goodRange < positionX && positionX < judgePosition + goodRange){
            Message(1);
            GameManager.instance.combo += 1;
            GameManager.instance.good += 1;
            GameManager.instance.noteCount += 1;
            Destroy(this.gameObject);

        }else if(judgePosition - badRange < positionX && positionX < judgePosition + badRange){
            Message(2);
            GameManager.instance.combo = 0;
            GameManager.instance.miss += 1;
            GameManager.instance.noteCount += 1;
            Destroy(this.gameObject);

        }
    }

    void Message(int judge){
        //GameObject message = (GameObject)Resources.Load("Miss");
        Instantiate(MessageObj[judge],new Vector3(-8f,0f,1.1f),Quaternion.Euler(90,0,0));
        //Instantiate(MessageObj)
    }



}