using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed=60f;

    void Update(){
        Rotate();
    }

    protected virtual void Rotate(){ //virtual : 자식들이 해당 함수를 덮어씌울수 있음. 
        transform.Rotate(speed*Time.deltaTime,0,0); //x방향으로 speed만큼 회전. 

    } //자식들은 접근가능. 바깥에서는 접근 x

    //baseRotater를 상속받는 자식들이 알아서 회전 방향을 지정하게 하기. 
    //BaseRotater의 자식들이 내부의 요소(회전 방향)을 바꾸도록 함.
}
