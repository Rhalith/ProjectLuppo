using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCheck : MonoBehaviour
{
    public MaterialCreator mc;
    private void OnDestroy()
    {
        mc.check = false;
    }
}
