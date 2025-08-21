using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashDisplayScript : MonoBehaviour
{
    public SO_Trash trash;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = trash.trashSprite;
        GetComponent<SpriteRenderer>().color = trash.trashColor;

        transform.localScale = new Vector3(trash.size * trash.spriteSize, trash.size * trash.spriteSize, 1f);

        GetComponent<CircleCollider2D>().radius = 1 / trash.spriteSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
