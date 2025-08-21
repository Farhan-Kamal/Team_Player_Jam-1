using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellerScript : MonoBehaviour
{
    public int goldGiven;

    public List<SO_Trash> wantedTrashList;
    public int wantedTrashInt;

    void Start()
    {
        for (int i = 0; i < wantedTrashInt; i++)
        {
            wantedTrashList.Add(trashManagerScript.instance.trashArray[Random.Range(0, trashManagerScript.instance.trashArray.Length)]);
        }
    }


}
