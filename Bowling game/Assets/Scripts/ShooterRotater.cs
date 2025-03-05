using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRotater : MonoBehaviour
{
   private enum RotateState{
    Idle, Vertical, Horizontal, Ready /*숫자이지만 사람에게 의미가 있는 단어로 변환. RotateState가 가질 수 있는 네가지의 상태.*/
   }

   private RotateState state=RotateState.Idle; /*처음 시작했을 때의 상태: idle*/

   public float verticalRotateSpeed=360f;

   public float horizontalRotateSpeed=360f;

   public BallShooter ballShooter;



    void Update()
    {

        switch(state)
        {
            case RotateState.Idle:
                if(Input.GetButtonDown("Fire1"))
                {
                state=RotateState.Horizontal;
                }
            break;

            case RotateState.Horizontal:
                if(Input.GetButton("Fire1")){
                transform.Rotate(new Vector3(0,horizontalRotateSpeed*Time.deltaTime,0));
                }
            else if(Input.GetButtonUp("Fire1")){
                state=RotateState.Vertical;
                }
            break;

            case RotateState.Vertical:
                if(Input.GetButton("Fire1")){
                    transform.Rotate(new Vector3(-verticalRotateSpeed*Time.deltaTime,0,0));
                    }
                else if (Input.GetButtonUp("Fire1")){
                    state=RotateState.Ready;
                    ballShooter.enabled=true;
                    }
            break;

            case RotateState.Ready:
            break;
        }
    }

    private void OnEnable(){

        transform.rotation=Quaternion.identity;//identity: 0,0,0의 회전.
        state=RotateState.Idle;
        ballShooter.enabled=false;
    }
}