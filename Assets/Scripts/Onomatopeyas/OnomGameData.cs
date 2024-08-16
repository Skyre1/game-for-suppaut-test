using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Onom", menuName = "Data/Onom Data")]
public class OnomGameData : ScriptableObject
{
    public string audioName;
    public string animalName;
    public string descriptiveText;
    public Sprite sprite;
    public AudioClip audioClip;
}
