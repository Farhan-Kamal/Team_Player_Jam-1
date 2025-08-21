using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistOverScene : MonoBehaviour
{
    public static List<GameObject> objectList;

    void Start()
    {
        bool shouldSaveObject = true;
        foreach (GameObject obj in objectList)
        {
            if (obj.name != gameObject.name)
            {
                shouldSaveObject = false;
            }
        }
        if (shouldSaveObject)
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
