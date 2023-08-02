using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HosomakiDisplay : MonoBehaviour
{
    public HosomakiObject Hosomaki;
    Renderer OuterWrapRend;
    Renderer InnerWrapRend;
    Renderer FillingRend;



    public GameObject OuterWrap;
    public GameObject InnerWrap;
    public GameObject Filling;
    void Start()
    {

        OuterWrapRend = OuterWrap.GetComponent<MeshRenderer>();
        OuterWrapRend.enabled = true;
        InnerWrapRend = InnerWrap.GetComponent<MeshRenderer>();
        InnerWrapRend.enabled = true;
        FillingRend = Filling.GetComponent<MeshRenderer>();
        FillingRend.enabled = true;

        OuterWrapRend.material = Hosomaki.OuterWrap;
        InnerWrapRend.material = Hosomaki.InnerWrap;
        FillingRend.material = Hosomaki.Filling;
    }
}
