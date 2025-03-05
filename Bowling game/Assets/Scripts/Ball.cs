using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public LayerMask WhatIsProp;

    public ParticleSystem explosionParticle;
    public AudioSource explosionAudio;

    public float maxDamage=100f; /*물건들이 자기 체력보다 더 큰 데미지를 받으면>>부서짐.*/

    public float explosionForce=100f; 
    
    /*물건들이 맵 바깥으로 날아가서 파괴되지 않는 경우 대비>> 10초 이상 파괴되지 않으면 스스로를 파괴하게끔.*/
    public float lifeTIme=10f;

    public float explosionRadius=20f;

    void start(){

        Destroy(gameObject,lifeTIme); /*자기 자신을 10초 뒤에 파괴.*/
    }

    private void OnTriggerEnter(Collider other){ /*자기 자신의 자식 요소와 부모자식관계 해제.*/
        /*구의 중심과 반지름을 지정하면 그 안에 겹치는 콜라이더를 가져와주는 유니티의 함수. coliders 로 받아옴.*/
        Collider[] colliders = Physics.OverlapSphere(transform.position,explosionRadius,WhatIsProp);
        /*성능 아끼기 위해 프롭인 것만 가져오도록 레이어마스크 추가*/

        for(int i=0; i < (colliders.Length); i++)//컬라이더 순회
        {
            Rigidbody targetRigidbody=colliders[i].GetComponent<Rigidbody>();//각 컬라이더의 리기드바디 가져오기

            targetRigidbody.AddExplosionForce(explosionForce,transform.position,explosionRadius);
            //폭발의 위치, 반경, 힘을 지정하면 알아서 튕겨나가는 효과를 재생하는 함수.

            Prop targetProp=colliders[i].GetComponent<Prop>();
            //현재순번 컬라이더에서 프롭 가져오기.

            float damage=CalculateDamage(colliders[i].transform.position);
            //calculatedamage에 위치 넣어주면 데미지 계산됨.

            targetProp.TakeDamage(damage); 
        }

        explosionParticle.transform.parent=null;
        explosionParticle.Play();
        explosionAudio.Play();

        Destroy(explosionParticle.gameObject,explosionParticle.duration/*파티클의 러닝타임 자동으로 지정.*/);
        Destroy(gameObject);

    }

    /*물체가 받는 데미지 계산*/
    /*데미지를 차등으로 주기: 폭발의 근원지(볼의 위치)와 가까울수록 높게, 멀수록 낮게.*/
    /*볼의 위치와 프롭(상대방)의 위치 계산 가능.*/
    //프롭(상대방)이 원의 안쪽으로 얼마나 들어와 있는가? 
    //radius(반지름), 볼-프롭 간 거리(x)일때
    //(radius-x)/radius 만큼 데미지 주기. x가 0일때(프롭==볼의 위치일때): 데미지 100퍼, x가 radius일때: 데미지 0퍼(x가 구 범위 내에는 있는데 볼에서 가장 멀리 떨어질때)

    private float CalculateDamage(Vector3 targetPosition){
        Vector3 explosionToTarget= targetPosition-transform.position;
        // 나의 위치에서 상대방의 위치까지 가는 거리.
        float distance=explosionToTarget.magnitude;
        //실제로는 원의 엣지에서 안쪽으로 얼마나 들어가 있는지를 알아야함.
        float edgeToCenterDistance=explosionRadius-distance;

        float percentage=edgeToCenterDistance/explosionRadius;

        float damage=maxDamage*percentage;

        damage=Mathf.Max(0,damage); /*데미지가 0보다 작은값이 들어오면 0으로 바뀜.*/

        return damage;


        //주의사항
        /*폭발 반경과 살짝 걸치는 콜라이더들은?
        실제 위치(중심)은 폭발 반경과 겹치지 않는데 부피가 있어서 걸치는 것처럼 보이는 것처럼 보이는 콜라이더들
        >>마이너스 데미지(체력 회복)이 됨.*/
    }
}
