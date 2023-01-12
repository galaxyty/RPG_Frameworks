
// 풀매니저에 영향을 받을 오브젝트.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    public abstract class BaseObject : MonoBehaviour
    {
        // 풀 오브젝트 Pop 할 때마다 실행.
        public abstract void Initialization();

        // 풀 오브젝트 Push 할 때마다 실행.
        public abstract void DisposeObject();
    }
}