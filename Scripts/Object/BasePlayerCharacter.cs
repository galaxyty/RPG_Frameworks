
// 플레이어 기본 뼈대.

/*
    - 구현 목록 -

    1. WSAD 이동 구현.
    2. 마우스를 통해 좌, 우 회전 구현.
    3. m_Speed 변수를 통해 이동속도 조절 가능.

    Move함수와 ThreeView함수는 상속받으면 Update문에 선언해줄 것.

    ex)
    public class Player : BasePlayerCharacter
    {
        private void Update()
        {
            ThreeView();
            Move();
        }
    }
 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

public class BasePlayerCharacter : BaseCharacter
{
    // 이동속도.
    [SerializeField]
    protected int m_Speed;

    public override void Initialization()
    {
    }

    public override void DisposeObject()
    {   
    }

    // 캐릭터 이동 WSAD.
    public virtual void Move()
    {
        // 키를 꾹 입력 했을 시.
        if (Input.GetKey(KeyCode.W))
        {
            W_Key();
        }

        if (Input.GetKey(KeyCode.S))
        {
            S_Key();
        }

        if (Input.GetKey(KeyCode.A))
        {
            A_Key();
        }

        if (Input.GetKey(KeyCode.D))
        {
            D_Key();
        }



        // 키를 떼었을 경우.
        if (Input.GetKeyUp(KeyCode.W))
        {
            W_KeyUp();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            S_KeyUp();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            A_KeyUp();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            D_KeyUp();
        }
    }

    // 3인칭 마우스 회전.
    public virtual void ThreeView()
    {
        // 좌, 우 회전을 위해 마우스 회전 값 구해옴.
        float posX = Input.GetAxis("Mouse X");

        // 마우스 좌우 회전.
        Quaternion qt = transform.rotation;
        qt.eulerAngles = new Vector3(qt.eulerAngles.x, qt.eulerAngles.y + posX, qt.eulerAngles.z);

        transform.rotation = qt;
    }

    // 앞 움직임.
    public virtual void W_Key()
    {
        transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
    }

    // 앞 움직임 키 뗐을 시.
    public virtual void W_KeyUp()
    {
    }

    // 뒤 움직임.
    public virtual void S_Key()
    {
        transform.Translate(Vector3.back * m_Speed * Time.deltaTime);
    }

    // 뒤 움직임 키 뗏을 시.
    public virtual void S_KeyUp()
    {
    }

    // 왼쪽 움직임.
    public virtual void A_Key()
    {
        transform.Translate(Vector3.left * m_Speed * Time.deltaTime);
    }

    // 왼쪽 움직임 키 뗏을 시.
    public virtual void A_KeyUp()
    {        
    }

    // 오른쪽 움직임.
    public virtual void D_Key()
    {
        transform.Translate(Vector3.right * m_Speed * Time.deltaTime);
    }

    // 오른쪽 움직임 키 뗏을 시.
    public virtual void D_KeyUp()
    {
    }
}
