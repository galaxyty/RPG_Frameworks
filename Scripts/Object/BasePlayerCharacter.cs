
// 플레이어 기본 뼈대.

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
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * m_Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * m_Speed * Time.deltaTime);
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
}
