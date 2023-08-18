using UnityEngine;

public class TrashCan : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.OnLeftMouseUpOver += OnLeftMouseUpOver;
    }

    private void OnLeftMouseUpOver(RaycastHit hit)
    {
        if(hit.collider.CompareTag("TrashCan"))
        {
            OrderController.Instance.DestroyOrder();
        }
    }
}
