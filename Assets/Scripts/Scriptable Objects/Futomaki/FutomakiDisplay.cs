using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FutomakiDisplay : MonoBehaviour
{
    public FutomakiObject futomaki;
    Renderer _fillingRend;
    public string sushiName;

    public GameObject[] filling;
    void Start()
    {
        var scriptableObject = Resources.Load<ScriptableObject>("Assets/Futomaki/" + sushiName);
        foreach (GameObject go in filling)
        {
            _fillingRend = go.GetComponent<MeshRenderer>();
            _fillingRend.enabled = true;
            int index = System.Array.IndexOf(filling, go);
            _fillingRend.material = futomaki.filling[index];
        }

    }
}
