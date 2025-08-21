using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sellAreaScript : MonoBehaviour
{
    public List<SO_Trash> sellingTrash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trash")
        {
            GameObject.Find("TrashManager").GetComponent<trashManagerScript>().collectedTrash.Add(collision.gameObject.GetComponent<trashDisplayScript>().trash);
            Destroy(collision.gameObject);
        }
    }
}
