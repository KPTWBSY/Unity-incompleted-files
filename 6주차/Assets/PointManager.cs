using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
//점수 관리: 마이너스가 되면 안 됨. 일정 이상의 점수를 막아야 함. >> 함수를 거치도록 강제. 
{
    public int point{ //바깥에서 point라는 변수 사용>> get과 set을 사용하게 됨
    //point=100; >> get, set 발동. 
        get{
            return m_point;
        }
        set{
            if(value<0){
                m_point=0;
            }
            else{
                m_point=value;
            }
        }
    }
    
    
    private int m_point=0;
 
}
