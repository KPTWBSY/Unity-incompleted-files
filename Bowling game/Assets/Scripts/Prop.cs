using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public int score=5; /*자기자신이 파괴되었을때 증가하는 점수.*/

    public ParticleSystem explosionParticle;
    /*파괴되었을 때 재생하는 효과. 미리 가지고있는것 아니고 파괴되는 즉시 프리팹에서 하나 찍어내기.*/

    public float hp=10f;

    public void TakeDamage(float damage){
        hp-=damage;

        if (hp<=0){
            /*Instantiate():원본 오브젝트를 괄호안에 넣으면 복사본을 만들어서 찍어냄. 어디에 찍어낼지 위치, 회전 의 옵션을 줄 수 있음.*/
            ParticleSystem instance=Instantiate(explosionParticle,transform.position, transform.rotation);

            AudioSource explosionAudio=instance.GetComponent<AudioSource>();
            explosionAudio.Play();

            Destroy(instance.gameObject,instance.duration);
            gameObject.SetActive(false); /*프롭: 파괴되는 것 아니고 off 상태로 모양만 사라짐.*/
        }
    }
}
