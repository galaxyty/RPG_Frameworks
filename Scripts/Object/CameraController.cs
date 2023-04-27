using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BaseRPG_V1;

// 이 카메라가 해당 타겟을 따라다님.
public class CameraController : BaseObject
{
    [SerializeField]
    private float cameraSpeed = 5.0f;

    // 따라다닐 타겟.
    private Transform target;

    private void LateUpdate()
    {
        transform.position = new Vector3(target.position.x - 0.52f, transform.position.y, target.position.z - 6.56f);

        transform.LookAt(target);
    }
    
    public override void Initialization()
    {
    }

    public override void DisposeObject()
    {
        target = null;
    }

    // 대상 타겟 셋팅.
    public void SettingTarget(GameObject obj)
    {
        target = obj.transform;
    }
}
