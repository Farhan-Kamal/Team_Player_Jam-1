using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "trash", menuName = "Trash")]
public class SO_Trash : ScriptableObject
{
    //change to sprite once we have sprites
    public Color trashColor;

    public int gold;
    public float weight;
    public float size;
}
