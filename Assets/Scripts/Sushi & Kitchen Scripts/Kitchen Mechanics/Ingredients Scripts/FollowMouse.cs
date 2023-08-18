using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            if(gameObject.name.Equals("CucumberBlueprintNew(Clone)"))
            {
                transform.position = new Vector3(hit.point.x - 8, hit.point.y, hit.point.z + 2);
            }
            else
            {
                transform.position = hit.point;
            }
        }
    }
}

