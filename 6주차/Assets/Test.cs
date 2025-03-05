using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour 
{
    // Start is called before the first frame update
    void Start()
    {
        Cat nate= new Cat(); //new class이름 >> 해당 클래스를 새로 메모리상에서 찍어냄. 
        nate.name="Nate"; //Cat 내부에 name을 만들지는 않았지만 부모인 Animal에 name이 있기때문에 name으로 접근가능. 
        nate.weight=1.5f;
        nate.year=3;

        Dog jack=new Dog();
        jack.name="Jack";
        jack.weight=5f;
        jack.year=2;

        //Animal someAnimal; //비어있는 변수. 
        Animal someAnimal jack; //Animal로 jack을 가져오면 Dog의 고유함수는 사용 불가, Animal의 함수인 print는 사용 가능. 
        //jack의 고유한 기능인 Hunt가 메모리상에서 사라지는 것이 아니라, Animal로서 다루고 있기 때문에 Animal로서의 고유기능만 사용 가능함. 
        Dog myDog=(Dog)someAnimal;
        myDog.Hunt(); //다시 jack을 Animal에서 Dog으로 변환 가능. 

        Animal[] animals=new Animal[2];
        animals[0]=nate; 
        animals[1]=jack; //다형성 >> 공통된 특징들을 한번에 다루기. >>코드를 깔끔하게 만들 수 있다. 

        for (int i=0; i<animals.Length; i++;){
            animals[i].Print();
        }



        nate.Stealth(); //고양이 nate의 고유 함수
        nate.Print(); // 부모 Animal의 공통 기능

        jack.Hunt(); //개 jack의 고유 함수
        jack.Print(); //부모의 공통 기능. 
    }

}
//Monobehaviour: 유니티가 제공하는 기본 기능을 상속받을 수 있음. Animal에는 Monobehavior가 붙어있지 않기 때문에 어떤 오브젝트에 부품으로 붙을 수 없음