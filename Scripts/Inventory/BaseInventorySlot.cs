using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRPG_V1
{
    public class BaseInventorySlot : BaseObject
    {
        // 아이템 인덱스.
        protected int m_Index;

        // 인덱스 텍스트 UI.
        [SerializeField]
        protected Text m_TextOfIndex;
        
        public override void Initialization()
        {
        }

        public override void DisposeObject()
        {
        }
    }
}
