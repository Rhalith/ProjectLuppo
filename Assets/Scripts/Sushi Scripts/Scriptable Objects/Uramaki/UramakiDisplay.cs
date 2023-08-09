using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UramakiDisplay : MonoBehaviour
{
    public UramakiObject uramaki;
    Renderer _fillingRend;

    public GameObject rice;
    public GameObject[] filling;
    void Start()
    {
        _fillingRend = rice.GetComponent<MeshRenderer>();
        _fillingRend.enabled = true;
        _fillingRend.material = uramaki.rice;

        foreach (GameObject go in filling)
        {
            _fillingRend = go.GetComponent<MeshRenderer>();
            _fillingRend.enabled = true;
            int index = System.Array.IndexOf(filling, go);
            _fillingRend.material = uramaki.filling[index];
        }

    }
}
