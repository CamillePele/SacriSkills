using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "new CompétenceDatas")]
public class CompétenceDatas : ScriptableObject
{
    public string titre;
    public string methodInput;
    [TextArea]public string description;
    public Sprite icon;
}