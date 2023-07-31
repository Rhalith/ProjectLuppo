using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerCam : MonoBehaviour
{
    //position cannot be float, needs to be vector3
    float previousMousePosition;
    public float moveSpeed;
    //use new input system



    private void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);
        
        if (Input.GetKey(KeyCode.A))
            {
                inputDir.x = +0.1f;
            }

        if (Input.GetKey(KeyCode.D))
        {
            inputDir.x = -0.1f;
        }


        Vector3 moveDir = transform.right * inputDir.x;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        
    }

}
