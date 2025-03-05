using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour 
//총 3가지 상태를 가짐.
//1) 라운드를 대기하는 상태 2) 포탄 발사를 대기하는 상태 3) 포탄을 실제로 발사해서 포탄을 추적하는 상태
{
    public enum State{
        Idle,Ready,Tracking //세 가지 상태 enum을 통해 표현. 
    }

    private State state{ //property란? 바깥에선 변수처럼 사용하지만 내부에서는 함수처럼 동작하도록 내부 처리 삽입 가능. 
        set{ //누군가가 equal을 통해서 값을 전달할 때 set 안에 있는 처리들이 실행됨. 
            switch(value){ //바깥에서 들어온 value에 따라 작동 달리함
                case State.Idle:
                    targetZoomSize=roundReadyZoomsize;
                    break;
                case State.Ready:
                    targetZoomSize=readyShotZoomSize;
                    break;
                case State.Tracking: //발사 순간: 맵 전체를 볼 수 있도록 줌아웃. 
                    targetZoomSize=trackingZoomSize;
                    break;

            }
        }
    }

    private Transform target; //추적할 대상
    //추적에 지연 시간 부여(유니티 내장 기능으로 구현가능. 추적 위치로 바로 이동하는 것이 아니라 시간을 두고 부드럽게 이동)
    public float smoothTime=0.2f; //지연시간 지정.
    private Vector3 lastMovingVelocity; //마지막 프레임에 원하는 위치까지 얼마의 속도로 이동중이었는지를 나타냄. 
    private Vector3 targetPosition;

    private Camera cam; //확대 배율 조정하기 위해 카메라를 가져옴
    private float targetZoomSize=5f; //각각의 상태에 따른 줌 사이즈 지정. const: 한번 지정되면 값을 변경할 수 없음. 
    private const float roundReadyZoomsize=14.5f;
    private const float readyShotZoomSize=5f;
    private const float trackingZoomSize=10f;

    //줌 값도 부드럽게 값을 바꾸어줌. 
    private float lastZoomSpeed; //마지막 순간에 값이 얼마나 변경되었는지 알려줌>>이걸 알아야 smooth 기능을 적용할 수 있음. 


    void Awake(){ //Awake: start와 비슷하지만 한박자 빠르다. 
        cam=GetComponentInChildren<Camera>();
        //GetComponent:나 자신에게 붙어있는 컴포넌트를 가져옴. GetComponentInChildern: 자식으로 들어가서 컴포넌트를 가져옴. 
        state=State.Idle; //게임이 시작되었을 때의 상태. state라는 값은 변수처럼 전달되지만 State 내부의 동작을 보면 어떤 처리 과정이 포함되어 있음. 
        //함수 대신 property를 사용하는 이유: 처리를 간결하게 보이기 위해. 함수로 대체하는것도 가능. 
    }

    private void Move(){ //카메라가 타겟의 위치에 맞춰서 움직이게 함. 
        targetPosition=target.transform.position;
        Vector3 smoothPosition=Vector3.SmoothDamp(transform.position, targetPosition, ref lastMovingVelocity, smoothTime); //SmoothDamp: 시간을 지정하면 목적 위치까지 부드럽게 이동. 기본적으로 마지막 순간에 값이 얼마나 변경되었는지 요구. 
        //SmoothDamp: 첫번째 값으로 자신의 초기 위치를 받음. 두번째 값으로는 목적지를 넣음. 마지막 값으로 지연 시간을 넣어줌. 중간에 마지막 순간의 속도가 들어감.
        //(lastMovingVelocity) ref: smoothDamp라는 함수 내부에서 값이 변경되면 그대로 해당 값을 받아서 나온다. 
        //SmoothDamp: 속도를 담을 임시 컨테이너 변수 생성. 
        transform.position=smoothPosition;
    }
    private void Zoom(){//마찬가지로 지연시간을 줘서 줌을 부드럽게 해줌.
        float smoothZoomSize=Mathf.SmoothDamp(cam.orthographicSize,targetZoomSize,ref lastZoomSpeed, smoothTime);
        cam.orthographicSize=smoothZoomSize;
    }
    private void FixedUpdate(){ //일반 Update와 FixedUpdate의 차이점: 1초에 여러번 실행되는 것은 공통. 일반 업데이트는 화면이 한번 갱신될때마다(한 프레임마다) 실행. 렉이 걸려서 화면 갱신이 적어지면 적어진 만큼만 실행. 
    //Fixed는 간격을 정해놓으면 무조건 해당 간격을 맞춰서 실행. 정확한 처리를 요구할 때 사용.
        if(target!=null){//추적할 대상이 존재할 때. 
            Move();
            Zoom();
        }
    }
    public void Reset(){
        state=State.Idle;
    }

    public void SetTarget(Transform newTarget, State newState){
        target=newTarget;
        state=newState;
        //외부에서 카메라의 추적 대상과 카메라의 상태 지정 가능. 

    }
}
