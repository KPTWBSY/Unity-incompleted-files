using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZRotater : BaseRotater //BaseRotater를 상속한 함수 zrotater. 
{
    protected override void Rotate(){
        //부모에서 작성한 Rotate를 전부 여기에 쓴 코드로 대체. 
        //만약 부모 코드를 쓰면서도 거기에 뭔가 덧붙이고 싶다면?
        //>>base.Rotate();

        transform.Rotate(0,0,speed*Time.deltaTime);
        //baserotator의 Update문에 Rotate가 들어가 있기 때문에 ZRotator에서 따로 Update문을 작성할 필요 없음. 
        //baserotator의 Rotate 문 내부는 비워도 됨. (Rotate문의 구현 자체는 x,y,zrotator에서 모두 각자 다르게 자체적으로 구현. )
    }

}
