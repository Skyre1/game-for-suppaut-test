using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName ="Prax", menuName = "Data/Praxis Data")]
public class PraxisGameData : ScriptableObject
{
    [TextArea] public string description;
    public Sprite sprite;


}
