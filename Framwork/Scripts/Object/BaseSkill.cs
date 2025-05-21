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
        protected int m_Attack;

        // 쿨타임.
        [Header("쿨타임")]
        [SerializeField]
        protected int m_CoolTime;

        // 스킬 유지 시간.
        [Header("스킬 유지 시간")]
        [SerializeField]
        protected int m_SkillCount;

        // 최초 위치값.
        private Vector3 m_Vector = new Vector3();

        // 공격력.
        public int Attack
        {
            get
            {
                return m_Attack;
            }
        }

        // 생성 시 최초 위치 값 저장.
        public override void Initialization()
        {
            m_Vector = transform.localPosition;
        }

        // 풀로 돌아가면 위치값과 회전값 원래대로.
        public override void DisposeObject()
        {
            transform.localPosition = m_Vector;
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }

        // 스킬 시전 시 발동.
        public abstract void OnSkill();

        // 스킬에 피격 시 발동.
        public abstract void OnHit(ref int damage);

        // 스킬 유지 카운트.
        protected IEnumerator EEffect_Count()
        {
            // 일정 시간 후 스킬 Push.
            yield return new WaitForSeconds(m_SkillCount);
            PoolManager.Instance.Push(this);
        }
    }
}