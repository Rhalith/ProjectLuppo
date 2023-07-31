using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    //TODO: Not works, find a way for trash can
    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
