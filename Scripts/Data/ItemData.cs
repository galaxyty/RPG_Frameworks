using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    // 아이템 타입 열거형.
    public enum kITEM_TYPE
    {
        // 무기.
        Weapon,

        // 방어구.
        Armor,

        // 포션.
        Porsion
    }

    // 아이템 인덱스.
    public int INDEX;

    // 아이템 이름.
    public string ITEM_NAME;

    // 아이템 타입.
    public kITEM_TYPE ITEM_TYPE;
}
