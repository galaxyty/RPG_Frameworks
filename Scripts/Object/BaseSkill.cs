using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseRPG_V1
{
    public abstract class BaseSkill : BaseObject
    {
        // 공격력.
        [Header("공격력")]
        [SerializeField]
        private int m_Attack;

        [Header("쿨타임")]
        [SerializeField]
        private int m_CoolTime;

        [Header("다단 히트 간격")]
        [SerializeField]
        private int m_MultiHit;

        // 공격력.
        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }

        public override void Initialization()
        {
        }

        public override void DisposeObject()
        {
        }

        // 스킬 효과 발동.
        public abstract void OnSkill();
    }
}