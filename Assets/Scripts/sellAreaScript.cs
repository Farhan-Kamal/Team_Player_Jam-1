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
            sellingTrash.Add(collision.gameObject.GetComponent<trashDisplayScript>().trash);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "trash")
        {
            SO_Trash checkedTrash = collision.gameObject.GetComponent<trashDisplayScript>().trash;

            if (sellingTrash.Contains(checkedTrash))
            {
                sellingTrash.Remove(checkedTrash);
            }
        }
    }
}
