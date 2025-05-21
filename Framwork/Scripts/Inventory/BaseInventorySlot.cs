using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRPG_V1
{
    public abstract class BaseInventorySlot : BaseObject
    {
        // 인덱스 텍스트 UI.
        [SerializeField]
        protected Text m_TextOfIndex;

        // 아이템 이미지.
        [SerializeField]
        protected Image m_ImageOfItem;

        // 아이템 소지 데이터.
        protected ItemData m_Data;

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
