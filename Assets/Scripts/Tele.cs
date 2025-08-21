using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tele : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I have been Touched.");
        if (collision != null)
        {
            Debug.Log(collision.gameObject.CompareTag("p1"));
            if (collision.gameObject.CompareTag("p1"))
            {
                SceneManager.LoadScene("Combat", LoadSceneMode.Additive);
            }
        }
    }
}
