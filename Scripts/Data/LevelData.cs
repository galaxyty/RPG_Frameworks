using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    // 레벨 인덱스.
    public int INDEX;

    // 해당 레벨.
    public int LV;

    // 다음 레벨로 넘어가기 위해 필요한 경험치량.
    public int EXP;
}
