using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{

    public float NoteSpeed = 13.334f;
    public float perfectRange;
    public float goodRange;
    public float badRange;
    private float judgePosition = -8.0f;
    //bool start;
    bool stop = false;
    bool end = false;
    int ballonCount = 1;
    public GameObject[] MessageObj;
    public int objectID;
    AudioSource balloonAudio;
    public AudioClip balloonSound;

      void Update()
    {
        if(GameManager.instance.start){
            if(stop && !end){
                if(GameManager.instance.autoPlay){
                    ballonCount -= 1;
                }else{
                    if((Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.J))){
                        ballonCount -= 1;
                    }
                }
            }else{
                transform.position += transform.forward * Time.deltaTime * NoteSpeed;
            }
            
        }



        if(transform.position.x <= -8){
            stop = true;
        }else if(transform.position.x <= -9){
            Destroy(this.gameObject);
        }
        if(ballonCount <= 0){
            //Debug.Log("1");
            KeySound.instance.BreakBalloon();
            GameManager.instance.noteCount += 1;
            Destroy(this.gameObject);
            return;
            
        }
        if(objectID == GameManager.instance.noteCount - 1){
            Debug.Log(2);
            stop = false;
            end = true;
            //Debug.Log(objectID);
            //KeySound.instance.BreakBalloon();
            //Destroy(this.gameObject);
            GameManager.instance.noteCount += 1;
        }

    }
  


    void Judgement(float positionX){
        if(judgePosition - perfectRange < positionX && positionX < judgePosition + perfectRange){
            //Debug.Log("Good");
            Message(0);
            
            Destroy(this.gameObject);
            //GameManager.instance.combo += 1;
            //GameManager.instance.perfect += 1;
            GameManager.instance.noteCount += 1;
        }else if(judgePosition - goodRange < positionX && positionX < judgePosition + goodRange){
            Message(1);
            
            Destroy(this.gameObject);
            //GameManager.instance.combo += 1;
            //GameManager.instance.good += 1;
            GameManager.instance.noteCount += 1;
        }else if(judgePosition - badRange < positionX && positionX < judgePosition + badRange){
            Message(2);
            
            Destroy(this.gameObject);
            //GameManager.instance.combo = 0;
            //GameManager.instance.miss += 1;
            GameManager.instance.noteCount += 1;
        }
    }

    void Message(int judge){
        //GameObject message = (GameObject)Resources.Load("Miss");
        Instantiate(MessageObj[judge],new Vector3(-8f,0f,1.1f),Quaternion.Euler(90,0,0));
        //Instantiate(MessageObj)
    }



}
