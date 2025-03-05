using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//유니티가 만들어준 기능을 사용.


public class hunity : MonoBehaviour
{
    // Start is called before the first frame update
    //게임 시작되면 가장먼저 실행되는 지점.
    /*여러 줄 주석*/
    void Start()
    {

        //콘솔 출력
        Debug.Log("Hello World");

    int age=23;
    int money=1000;
    Debug.Log(age);
    Debug.Log(money);

    float height=100.987f;
    //소숫점 아래 7자리까지만 정확. 32비트 사용

    double pi=3.14152926;
    //64비트 사용. 소숫점 아래 15자리까지 정확. 성능은 좋지 않아서 플롯을 주로 사용

    bool isBoy=true;
    bool isGirl=false;
    //True or False만

    char grade='A';
    //문자 한개

    string movieTitle="stringstring";
    //문장

    Debug.Log("내 나이는 "+age);
    Debug.Log("내가 가진 돈은 "+money);
    Debug.Log("내 키는"+height);

    var myName="iii";
    //var: 할당하는 값을 기준으로 타입 결정
    //string myName="iii" 와 같은 코드.
    }

}
