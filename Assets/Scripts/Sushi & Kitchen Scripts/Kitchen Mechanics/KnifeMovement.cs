using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMovement : MonoBehaviour
{
    public void ReceiveHorizontalInput(float movementInput)
    {
        if(!IngredientController.Instance.IsCutting)
        {
            Vector3 moveDir = Vector3.right * movementInput;

            transform.position += moveDir * 0.5f * Time.deltaTime;
        }
    }
}
