using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonLight : MonoBehaviour
{
    public static DonLight instance = null;
    [SerializeField] private float speed = 3;
    //[SerializeField] private int num = 0;
    private Renderer rend;
    private float alfa = 0;
    void Start()
    {
        rend = GetComponent<Renderer>();
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(rend.material.color.a <= 0)){
            rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
        }
        if(!GameManager.instance.autoPlay){
            if(Input.GetKeyDown(KeyCode.F)){
                ColorChange();
            }
            if(Input.GetKeyDown(KeyCode.J)){
                ColorChange();
            }
        }
        alfa -= speed * Time.deltaTime;
        
    }

    public void ColorChange(){
        alfa = 0.3f;
        rend.material.color = new Color(rend.material.color.r,rend.material.color.g,rend.material.color.b,alfa);
    }
}
