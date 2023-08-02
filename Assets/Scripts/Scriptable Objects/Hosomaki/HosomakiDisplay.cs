using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HosomakiDisplay : MonoBehaviour
{
    public HosomakiObject hosomaki;
    Renderer _fillingRend;

    public GameObject filling;
    public GameObject filling2;
    void Start()
    {

        _fillingRend = filling.GetComponent<MeshRenderer>();
        _fillingRend.enabled = true;
        _fillingRend.material = hosomaki.filling;

        _fillingRend = filling2.GetComponent<MeshRenderer>();
        _fillingRend.enabled = true;
        _fillingRend.material = hosomaki.filling2;
    }
}
