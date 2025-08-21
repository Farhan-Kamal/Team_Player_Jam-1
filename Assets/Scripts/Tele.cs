using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        if (LoadedScene == null)
        {
            LoadedScene = new List<UnityEngine.SceneManagement.Scene>();
        }
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
        LoadedScene.Clear();
        LoadedScene.Add(SceneManager.GetActiveScene());
        LoadedScene.Add(SceneManager.GetActiveScene());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("p1") || collision.gameObject.CompareTag("p2"))
            {
                Teleport(newSceneName, finalPos, collision.gameObject);
            }
        }
    }

    public void Teleport(string sceneName, Vector3 pos, GameObject player)
    {
        bool isSceneLoaded = false;
        foreach (Scene scene in LoadedScene)
        {
            if (scene.name == sceneName)
            {
                isSceneLoaded = true;
            }
        }
        if (!isSceneLoaded)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }
        Scene newLoadScene = SceneManager.GetSceneByName(sceneName);

        LoadedScene.Add(newLoadScene);

        Scene unloadedScene;

        if (player.CompareTag("p1"))
        {
            unloadedScene = scene_p1;
            scene_p1 = newLoadScene;
        }
        else
        {
            unloadedScene = scene_p2;
            scene_p2 = newLoadScene;
        }

        player.gameObject.transform.position = pos;

        foreach (Scene scene in LoadedScene)
        {
            if (scene != scene_p1 && scene != scene_p2)
            {
                StartCoroutine(UnloadLater(unloadedScene));
            }
        }
    }

    IEnumerator UnloadLater(Scene unloadedScene)
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.UnloadSceneAsync(unloadedScene);
        LoadedScene.Remove(unloadedScene);
    }
}
