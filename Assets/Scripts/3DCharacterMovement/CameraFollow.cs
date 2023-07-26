using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform cameraPosition;

    //can change with cinemachine
    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
