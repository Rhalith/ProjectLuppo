using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChumakiDisplay : MonoBehaviour
{
    public ChumakiObject chumaki;
    Renderer _fillingRend;
    
    public GameObject[] filling;
    void Start()
    {
        foreach(GameObject go in filling) 
        {
            _fillingRend = go.GetComponent<MeshRenderer>();
            _fillingRend.enabled = true;
            int index = System.Array.IndexOf(filling, go);
            _fillingRend.material = chumaki.filling[index];
        }

    }
}
