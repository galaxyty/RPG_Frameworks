using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    // 태그.
    public enum kTAG
    {
        Player,
        MainCanvas,
        Weapon
    }

    // 번들 레이블.
    public enum kLABLE
    {
        script,
        character
    }

    // 번들명.
    public enum kBUNDLE
    {
        ITEM,
        PORSION,
        Player,
        Inventory,
        InventorySlot,
        UIInventory,
        UIInventorySlot,
        UICustomInventory,
        UICustomInventorySlot,
        JANGBI
    }
}
