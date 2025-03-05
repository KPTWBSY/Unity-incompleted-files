using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 고블린 : BaseMonster //basemonster 상속. 
{
//BaseMonster에서 껍데기로 남아있는 Attack을 완성해야 함. 
    public override void Attack(){
        Debug.Log("한 캐릭터 공격. 공격력: "+damage)
    }
}
