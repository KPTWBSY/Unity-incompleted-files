using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal  // class Animal : MonoBehaviour >> MonoBehaviour를 base로 Animal 클래스를 만든다. 
{
  //부모 클래스: 자식의 원형. 자식의 공통된 기능을 가진 클래스. 
  //Animal: animal의 기초적인 기능을 가짐.
  public string name;

  public float weight;

  public int year;

  public void Print(){
    Debug.Log(name+"몸무게: "+weight+"나이: "+year);
  }
  //동물이 스스로의 이름과 몸무게, 나이를 띄우는 함수

  protected float GetSpeed(){ //protected: public과 private의 중간. 부모 클래스의 자식 클래스에서는 쓸 수 있지만 그 외부에서는 접근하지 못함. 

    return CalcSpeed();//나이, 몸무게에 따른 동물의 속도를 구하기. 
  }

  private float CalcSpeed(){ //부모 클래스에서 private인 함수: 자식에서 보이지 않음. 자식 클래스에서 사용하면 에러가 뜸. 
    return 100f/(weight*year);
  }
}

public class Dog: Animal{ //Dog이 Animal의 모든 기능을 가진채로 시작.(Monobehavior 가 뒤에 붙는 것과 일맥상통)

    public void Hunt(){
        float speed=GetSpeed(); //Dog에게 GetSpeed를 만들지 않았지만 Animal에 있기 때문에 사용 가능. 
        //Animal에 있는 함수와 변수를 Dog에서도 접근해 수정 가능. 
        Debug.Log(speed+"의 속도로 사냥.");

        weight=weight+10f; //몸무게 증가. 
    }
    //상속: 부모 클래스의 코드를 자식이 상속해서 사용. 
    //Sandbox 패턴: 미리 필요한 기능을 부모 클래스에 모두 작성, 자식 클래스에서 부모 클래스의 기능을 조합해 자신만의 기능 만들기. 
    //부모 클래스에서는 작성한 기능을 어디에 사용할지는 정확히 모름. 
}
public class Cat: Animal{
    public void Stealth(){
        Debug.Log("숨었다");
        }
    } 




