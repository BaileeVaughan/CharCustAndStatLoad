using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    //texture indexes
    public int skinIndex;
    public int eyesIndex, mouthIndex, hairIndex, armourIndex, clothesIndex;
    //stats
    public string charName;
    public int[] stats;
    public string[] selectedClass;

    public DataToSave(CustSet cust)
    {
        skinIndex = cust.skinIndex;
        eyesIndex = cust.eyesIndex;
        mouthIndex = cust.mouthIndex;
        hairIndex = cust.hairIndex;
        armourIndex = cust.armourIndex;
        clothesIndex = cust.clothesIndex;
        charName = cust.charName;
        stats = cust.stats;
        selectedClass = cust.selectedClass;
    }
}
