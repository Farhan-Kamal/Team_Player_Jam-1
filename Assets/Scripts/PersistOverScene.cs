using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistOverScene : MonoBehaviour
{
    public static List<GameObject> objectList;

    void Start()
    {
        if (objectList == null)
        {
            objectList = new List<GameObject>();
        }

        bool shouldSaveObject = true;
        foreach (GameObject obj in objectList)
        {
            Debug.Log(obj.name);
            Debug.Log(gameObject.name);
            if (obj.name == gameObject.name)
            {
                shouldSaveObject = false;
            }
        }
        if (shouldSaveObject)
        {
            objectList.Add(gameObject);
            DontDestroyOnLoad(gameObject);
        }
    }
}
