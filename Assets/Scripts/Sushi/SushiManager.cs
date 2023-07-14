using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    private static SushiManager _instance;
    [SerializeField] private GameObject[] _sushiPrefabs;
    [SerializeField] private Sushi[] _availableSushis;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        _instance = this;

        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
