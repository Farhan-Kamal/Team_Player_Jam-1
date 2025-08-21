using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    private GameObject followObject;
    void Start()
    {
        followObject = transform.transform.parent.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = followObject.transform.position;
        followPos = new Vector3(followPos.x, followPos.y, followPos.z - 10);
        transform.position = followPos;
    }
}
