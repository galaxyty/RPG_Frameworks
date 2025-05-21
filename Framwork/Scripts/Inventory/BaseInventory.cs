using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BaseRPG_V1
{
    public class BaseInventory : BaseObject
    {
        // 스프라이트.
        [SerializeField]
        protected Image m_ImageOfBG;

        // 슬롯 갯수.
        [Header("슬롯 생성 갯수")]
        [SerializeField]
        protected int m_Count;

        // 그리드 영역.
        [Header("슬롯 생성 할 영역")]
        [SerializeField]
        protected GameObject m_Grid;

        public override void Initialization()
        {            
        }

        public override void DisposeObject()
        {            
        }
    }
}