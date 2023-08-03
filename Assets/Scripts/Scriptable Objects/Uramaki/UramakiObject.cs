using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Uramaki", menuName = "Edible/Sushis/Uramaki")]
public class UramakiObject : ScriptableObject
{
    public Material rice;
    public Material[] filling;
}
