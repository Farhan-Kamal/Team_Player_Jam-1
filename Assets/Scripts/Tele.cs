using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tele : MonoBehaviour
{
    public string newSceneName;
    public Vector3 finalPos;

    public static Scene scene_p1;
    public static Scene scene_p2;

    public static List<UnityEngine.SceneManagement.Scene> LoadedScene;

    private void Start()
    {
        if (scene_p1 == scene_p2)
        {
            StartCoroutine(DoLater());
        }
    }

    IEnumerator DoLater()
    {
        yield return new WaitForSeconds(0.5f);
        scene_p1 = SceneManager.GetActiveScene();
        scene_p2 = SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("p1") || collision.gameObject.CompareTag("p2"))
            {
                Scene newLoadScene = SceneManager.GetSceneByName(newSceneName);

                bool isSceneLoaded = false;

                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    if (SceneManager.GetSceneAt(i) == newLoadScene)
                    {
                        isSceneLoaded = true;
                    }
                }

                if (collision.gameObject.CompareTag("p1"))
                {
                    if (newLoadScene == scene_p2)
                    {
                        StartCoroutine(UnloadLater(scene_p1));
                    }
                    scene_p1 = newLoadScene;
                }
                else
                {
                    if (newLoadScene == scene_p1)
                    {
                        StartCoroutine(UnloadLater(scene_p2));
                    }
                    scene_p2 = newLoadScene;
                }

                if (!isSceneLoaded)
                {
                    SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);
                }

                collision.gameObject.transform.position = finalPos;
            }
        }
    }

    IEnumerator UnloadLater(Scene unloadedScene)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.UnloadSceneAsync(unloadedScene);
    }
}
