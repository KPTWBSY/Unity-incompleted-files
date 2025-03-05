using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public bool isOveraped=false;

    private Renderer myRenderer;

    public Color touchColor;
    private Color originalColor;

    void Start()
    {
        myRenderer=GetComponent<Renderer>();
        originalColor=myRenderer.material.color;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //트리거인 콜라이더와 충돌할때 자동으로 실행.

    void OnTriggerEnter(Collider other){

        if(other.tag=="Endpoint"){
            isOveraped=true;
            myRenderer.material.color=touchColor;
        }
    }

    void OnTriggerExist(Collider other){
        if(other.tag=="Endpoint"){
            isOveraped=false;
            myRenderer.material.color=originalColor;
        }
    }

    void OnTriggerStay(Collider other){
         if(other.tag=="Endpoint"){
            isOveraped=true;
            myRenderer.material.color=touchColor;
        }
    }
}
