using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    public abstract class BaseInventorySlot : BaseObject
    {   
        public override void Initialization()
        {
        }

        public override void DisposeObject()
        {
        }

        // 터치 이벤트.
        public abstract void OnTouchEvent();
    }
}
