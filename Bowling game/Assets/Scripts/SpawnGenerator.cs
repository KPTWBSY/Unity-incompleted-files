using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    public GameObject[] propPrefabs; //생성할 프롭들의 원본. 배열을 사용해서 가져옴.

    private BoxCollider area; //스폰 위치. 박스 콜라이더의 사이즈를 가져옴

    public int count=100; //찍어낼 게임오브젝트의 총 개수.

    //프롭들을 매번 새로 찍어내는 것>>성능낭비. 
    //다음  라운드로 넘어가는 순간 프롭들을 정위치로 돌리고(프롭 파괴 구현: 게임오브젝트를 끄는 방식으로 구현)
    //프롭들을 다시 다음 라운드에서 게임오브젝트 켜주고 위치만 섞어준다. 

    private List<GameObject> props=new List<GameObject>(); 
    // 위 기능을 구현하기 위해 모든 프롭들을 추적하기 위한 리스트. 

    void Start()
    {
        area=GetComponent<BoxCollider>();
        //처음 생성할 때: BoxCollider필요. 

        for(int i=0;i<count;i++){
            //count의 개수만큼 프롭을 찍어낸다. 
            Spawn();
        }
        area.enabled=false;
        //처음 생성 이후: BoxColider가 방해가 될 수 있음(다른 물체들과 충돌 발생)
        //>>BoxColider를 꺼준다. 
    }

    private void Spawn(){
        //스폰이 발동될때마다 하나의 오브젝트를 랜덤하게 찍어냄.

        int selection=Random.Range(0,propPrefabs.Length);
        //어떤 프롭을 생성할지 선택. Random.Range: maximum 값은 빼고 랜덤으로 반환. 최소, 최대값에 모두 정수 입력하면 정수만 랜덤값으로 반환.
        GameObject selectedPrefab=propPrefabs[selection]; //선택된 프롭
        Vector3 spawnPos=GetRandomPosition();
        GameObject instance=Instantiate(selectedPrefab,spawnPos,Quaternion.identity);
        props.Add(instance); //프롭 추적 리스트에 방금 생성한 프롭 등록.
    }

    private Vector3 GetRandomPosition(){
        //매번 새로운 위치를 지정해주는 함수. 
        //위치 범위: SpawnGenerator 위치(중심)에서 해당 BoxColider 사이즈의 반절만큼 x,y,z 방향으로 +또는 -.
        Vector3 basePosition=transform.position; //나 자신의 위치 기준으로 위치 지정.
        Vector3 size=area.size; //BoxColider의 size.

        float posX=basePosition.x+Random.Range(-size.x/2f,size.x/2f); //최대 최소 범위를 입력하면 랜덤한 값을 지정하는 range()
        float posY=basePosition.y+Random.Range(-size.y/2f,size.y/2f);
        float posZ=basePosition.z+Random.Range(-size.z/2f,size.z/2f);

        Vector3 spawnPos=new Vector3(posX,posY,posZ); //방금 구한 랜덤한 x,y,z 를 하나의 Vector3로 묶어줌.

        return spawnPos;
    }

    //라운드가 넘어갈 때마다 모든 프롭들의 위치 리셋.
    //프롭들이 파괴되었을 때>> 프롭들을 꺼줌
    //>>라운드가 넘어가면 다시 랜덤하게 위치를 지정함.
    //외부에서 접근할 수 있도록 public으로.
    public void Reset()
    {
        for (int i=0;i<props.Count;i++){ //props 리스트 안에 있는 모든 프롭들에 대해 실행. 
            props[i].transform.position=GetRandomPosition();
            props[i].SetActive(true); //전 라운드에서 파괴된 오브젝트(꺼져있음) 켜주기
        }
    }
}
