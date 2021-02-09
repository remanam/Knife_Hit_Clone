using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New BonusObjects spawn Data", menuName = "Bonus Objects Data", order = 51 )]
public class BonusObjectData : ScriptableObject
{
    public int minimalKnifeCount;
    public int maximumKnifeCount;
    public int knifeInLogChance;  // 0-100%

    public int appleInLogCount;
    public int appleInLogChance; // 0-100%
}
