using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCheck : MonoBehaviour
{
    private MaterialCreator mCreator;
    private void OnDestroy()
    {
        mCreator.check = false;
    }
}
