using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMonster : MonoBehaviour //추상 클래스 특징: 자식들이 BaseMonster를 상속받으면 무조건 Attack을 가지고 있어야 함. 
//인터페이스와 달리 내부 구현(void Update)이 어느정도 가능. 
//게임 도중에 해당 클래스를 찍어낼수는 없음. 
//필요한 부분들만 자식들이 오버라이드 하게 하고 어떻게 동작하는지는 BaseMonster 자체에서 구현. 
{
    public float damage=100f;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space)){
            Attack();
        }
    }

    public virtual void Attack(){ //virtual:자식이 해당 함수를 덮어쓸 수 있음

    }//Attack의 껍데기만 만들고 내부를 구현하지 않으려면? (virtual이어도 중괄호는 필요한데 이것도 없애기 위해)
    //인터페이스의 한계: 내부에 멤버 변수나 구현물이 들어가 있는 함수 구현 x. 
}

