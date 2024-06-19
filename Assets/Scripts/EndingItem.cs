using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;

[CreateAssetMenu(fileName = "EndingItem", menuName = "CLL4/Endingtem", order = 2)]

public class EndingItem : ScriptableObject
{

public string endingText;

public AK.Wwise.Event endingSound;

}
