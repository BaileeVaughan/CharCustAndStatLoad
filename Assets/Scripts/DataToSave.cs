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
    public int[] stats = new int[7];
    public string selectedClass;
    public string selectedRace;

    public DataToSave(CustSet cust)
    {
        skinIndex = cust.skinIndex;
        eyesIndex = cust.eyesIndex;
        mouthIndex = cust.mouthIndex;
        hairIndex = cust.hairIndex;
        armourIndex = cust.armourIndex;
        clothesIndex = cust.clothesIndex;
        charName = cust.charName;
        for (int i = 0; i < 7; i++)
        {
            stats[i] = (cust.stats[i] + cust.tempStats[i]);
        }
        selectedClass = cust.selectedClass[cust.selectedClassIndex];
        selectedRace = cust.selectedRace[cust.selectedRaceIndex];
    }
}
