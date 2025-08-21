using System.Collections;
using System.Collections.Generic;
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
}
