using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class math : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { /*
        int a=5;
        int b=7;
        int sum=a+b;
        Debug.Log(sum);

        sum=a-b;
        Debug.Log(sum);
    */

    /*int i=0;
    i=i+1;
    Debug.Log(i);

    i++;//i=i+1;

    i--;//i=i-1;

    Debug.Log(i);
    */

    int i=0;
    //0
    Debug.Log(i++);
    //1
    Debug.Log(i);
    //2
    Debug.Log(++i);

    int j=10;
    j=j+5;
    j+=5; //연산자의 축약
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
