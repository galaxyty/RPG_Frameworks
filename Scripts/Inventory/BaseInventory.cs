using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    public class BaseInventory : BaseObject
    {
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