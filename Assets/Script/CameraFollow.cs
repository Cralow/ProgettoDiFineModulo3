using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    Transform maincamera;
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
      
    }


    void LateUpdate()
    {
        maincamera.transform.position = new Vector3(transform.position.x, transform.position.y, -8);
    }
}
