using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHolder : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
