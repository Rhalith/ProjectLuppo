using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedController : MonoBehaviour
{
    private GameObject _instantiatedObject;

    private SeaweedWrap _seaweedWrap;

    private int _instantiatedIngredientCount;

    public static InstantiatedController Instance;

    public GameObject InstantiatedObject { get => _instantiatedObject; set => _instantiatedObject = value; }
    public SeaweedWrap SeaweedWrap { get => _seaweedWrap; set => _seaweedWrap = value; }
    public int InstantiatedIngredientCount { get => _instantiatedIngredientCount; set => _instantiatedIngredientCount = value; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public void ClearInstantiatedObject()
    {
        _instantiatedObject = null;
    }

}
