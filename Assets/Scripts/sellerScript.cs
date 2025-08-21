using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class sellerScript : MonoBehaviour
{
    public int goldGiven;

    public List<SO_Trash> wantedTrashList;
    public int wantedTrashInt;

    public GameObject sellMenu;
    private GameObject currentLoadedMenu;

    void Start()
    {
        for (int i = 0; i < wantedTrashInt; i++)
        {
            wantedTrashList.Add(trashManagerScript.instance.trashArray[Random.Range(0, trashManagerScript.instance.trashArray.Length)]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "p1")
        {
            currentLoadedMenu = Instantiate(currentLoadedMenu, Vector3.zero, Quaternion.identity);

            currentLoadedMenu.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "2";
            currentLoadedMenu.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "1";
            currentLoadedMenu.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = "3";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "p1")
        {
            Destroy(currentLoadedMenu);
        }
    }
}
