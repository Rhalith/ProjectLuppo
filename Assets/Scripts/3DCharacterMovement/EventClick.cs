using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class EventClick : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    private EventClick objectInstantiated;
    GameObject Seaweed;
    private bool clicked = false;

    private void OnMouseDown()
    {
        InstantiateObject(objectPrefab);

        if (!clicked)
        {
            if (GameObject.Find("Seaweed(Clone)"))
            {
                Seaweed = GameObject.Find("Seaweed(Clone)");
                objectInstantiated.transform.parent = Seaweed.transform;
            }
        }
        if (clicked)
        {
            if (GameObject.FindWithTag("Instantiated"))
            {
                Object.Destroy(objectInstantiated.gameObject);
            }
        }

        clicked = !clicked;
    }

    public void InstantiateObject(GameObject objectName)
    {
        this.objectInstantiated = Instantiate(objectName, transform.position, Quaternion.identity)
        .GetComponent<EventClick>();
        this.objectInstantiated.tag = "Instantiated";
    }
}
