using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UI 요소를 가져옴.

public class BallShooter : MonoBehaviour
{
    public Rigidbody ball;

    public Transform firePos;

    public Slider powerSlider;
    public AudioSource shootingAudio; //슈터피벗에 오디오소스 컴퍼넌트 추가하고 

    public AudioClip fireClip;
    public AudioClip chargingClip;

    public float minForce=15f;
    public float maxForce=30f; //충전하는 힘의 최대, 최소값 지정.
    public float chargingTime=0.75f; //min->max 까지 힘이 채워지는데 걸리는 시간.
    //1초에 힘이 얼마나 채워지는지 지정가능.
    private float currentForce;
    private float chargeSpeed;
    private bool fired; //발사했는지 체크>> 했으면 다음 라운드 전까지는 발사 불가능.

    private void OnEnable(){
        currentForce=minForce;//시작하는 힘: 최소
        powerSlider.value=minForce; //파워슬라이드의 값을 minForce(최소)로 지정
        fired=false;
    }

    private void Start(){
        chargeSpeed=(maxForce-minForce)/chargingTime; //1초에 얼마나 충전되어야 하는지
    }

    private void Update(){ 

        if (fired==true){
            return;
        }

        powerSlider.value=minForce;

        if(currentForce >= maxForce && !fired){ //힘이 max 이상이어서 발사를 해야하는 경우
            currentForce=maxForce;
            Fire();
            //발사처리
        }
        else if(Input.GetButtonDown("Fire1")){  //발사 버튼을 누르는 순간
            fired=false;
            currentForce=minForce;
            shootingAudio.clip=chargingClip;
            shootingAudio.Play();
            //충전용 소리로 오디오 교체 및 재생
        }
        else if(Input.GetButton("Fire1")&&!fired){ //발사 버튼을 누르고 있는동안
            currentForce=currentForce+chargeSpeed*Time.deltaTime; //현재 힘 값 계산.

            powerSlider.value=currentForce; //슬라이더 값을 현재 힘의 값으로 덮어씌우기
        }

        else if(Input.GetButtonUp("Fire1")&&!fired){ //발사하는 순간(발사 버튼에서 손을 떼는 순간)
            Fire();
        }
    }
    //onEnable: start와 비슷. 게임이 시작되면 자동으로 한번 발동. 
    //초기화 코드를 넣어서 라운드가 넘어갈 때마다 매번 실행시켜 매번 값 자동으로 초기화시켜주는 기능.

    private void Fire(){
        fired=true;
        Rigidbody ballInstance=Instantiate(ball,firePos.position,firePos.rotation); //원본을 instantiate하여 하나 찍어냄.

        ballInstance.velocity=currentForce*firePos.forward; //찍어낸 ball의 속도 지정

        shootingAudio.clip=fireClip;
        shootingAudio.Play(); //오디오 클립 발사용으로 바꾸고 재생.

        currentForce=minForce;
    }

}
