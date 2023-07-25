using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    float previousMousePosition;
    public float moveSpeed;
    private void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);
        if(Input.GetKey(KeyCode.Mouse1))
        {

            float currentMousePosition = Input.mousePosition.x;
            if(previousMousePosition < currentMousePosition)
            {
                inputDir.x = -0.1f;
            }

            if (previousMousePosition > currentMousePosition)
            {
                inputDir.x = +0.1f;
            }

            previousMousePosition = currentMousePosition;
        }

        Vector3 moveDir = transform.right
            * inputDir.x;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
        
    }
}
