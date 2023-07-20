using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    private static SushiManager _instance;
    private List<string> _availableIngredients = new();
    private List<Sushi> _availabeSushis = new();

    public List<string> AvailableIngredients { get => _availableIngredients; set => _availableIngredients = value; }


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

    List<Sushi> CreateSushis()
    {
        List<Sushi> sushiList = new List<Sushi>();

        Sushi sake = new Sushi("somon"); 
        sushiList.Add(sake);
        Sushi ebi = new Sushi("karides"); 
        sushiList.Add(ebi);
        Sushi ahi = new Sushi("tonbaligi", "soyasosu"); 
        sushiList.Add(ahi);
        Sushi unagi = new Sushi("yilanbaligi", "unagisos"); 
        sushiList.Add(unagi); 
        Sushi hamachi = new Sushi("sarikuyruk", "soyasosu"); 
        sushiList.Add(hamachi);

        return sushiList;
    }
}
