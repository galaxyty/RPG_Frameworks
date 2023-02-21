using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BaseRPG_V1;

public class BaseEquitmentSlot : BaseObject
{
    // 아이템 인덱스 텍스트.
    [Header("인덱스 표시 할 텍스트")]
    [SerializeField]
    protected Text m_TextOfIndex;

    public override void Initialization()
    {
    }

    public override void DisposeObject()
    {
    }
}
