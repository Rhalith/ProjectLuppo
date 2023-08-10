using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float moveSpeed = 7f;

    public void ReceiveHorizontalInput(float movementInput)
    {
        Vector3 moveDir = Vector3.right * movementInput;

        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
