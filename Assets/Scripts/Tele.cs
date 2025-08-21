using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tele : MonoBehaviour
{
    public string newSceneName;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("p1") || collision.gameObject.CompareTag("p2"))
            {
                SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);
            }
        }
    }
}
