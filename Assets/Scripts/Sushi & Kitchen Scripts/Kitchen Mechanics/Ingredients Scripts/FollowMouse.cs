using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            Debug.Log(hit.point);
            transform.position = hit.point;
        }
    }
}

