using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trashManagerScript : MonoBehaviour
{
    public static trashManagerScript instance;

    public SO_Trash[] trashArray;

    public List<SO_Trash> collectedTrash;

    private void Update()
    {
        instance = this;
    }

    public void Sell()
    {
        List<SO_Trash> soldTrash = GameObject.Find("Seller").GetComponent<sellerScript>().wantedTrashList;
    }
}
