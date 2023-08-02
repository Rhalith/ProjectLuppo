using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Futomaki", menuName = "Edible/Sushis/Futomaki")]
public class FutomakiObject : MonoBehaviour
{
    public GameObject OuterWrap;
    public GameObject InnerWrap;
    public Material[] Filling;
}
