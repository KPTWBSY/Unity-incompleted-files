using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hellofunction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        float sizeofcircle=30f;
        float radius=Getradius(sizeofcircle);
        Debug.Log("원의 사이즈: "+sizeofcircle+ "원의 반지름"+radius);
        // 넓이가 주어졌을때 반지름 구하는 함수
    }

    float Getradius(float size)
    {
        float pi=3.14f;
        float tmp=size/pi;
        float radius=Mathf.Sqrt(tmp); //점 연산자: 어떤 내부의 요소를 가져옴. (ex: Math 안의 요소 가져오기, Unity 엔진 안의 요소 가져오기..)
    }

}

//스코프: 변수가 관측가능한 영역. 중괄호가 시작하고 끝나는 시점
//변수 이름이 같아도 함수 안에서의 변수와 밖에서의 변수는 다른 변수. 