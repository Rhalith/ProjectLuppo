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

        //TODO: Change this to a more elegant way
        Sushi sake = new Sushi(SushiType.Sashimi,"somon"); 
        sushiList.Add(sake);
        Sushi ebi = new Sushi(SushiType.Sashimi, "karides"); 
        sushiList.Add(ebi);
        Sushi ahi = new Sushi(SushiType.Sashimi, "tonbaligi", "soyasosu"); 
        sushiList.Add(ahi);
        Sushi unagi = new Sushi(SushiType.Sashimi, "yilanbaligi", "unagisos"); 
        sushiList.Add(unagi); 
        Sushi hamachi = new Sushi(SushiType.Sashimi, "sarikuyruk", "yuzu", "soyasosu"); 
        sushiList.Add(hamachi);
        Sushi tako = new Sushi(SushiType.Sashimi, "ahtapot");
        sushiList.Add(tako);
        Sushi ebiNigiri = new Sushi(SushiType.Nigiri, "pismistereyaglikarides", "pirinc", "kombuyosunu");
        sushiList.Add(ebiNigiri);
        Sushi tamagoNigiri = new Sushi(SushiType.Nigiri, "omlet", "kombuyosunu", "pirinc");
        sushiList.Add(tamagoNigiri);
        Sushi unagiNigiri = new Sushi(SushiType.Nigiri, "izgaratatlisuyyilanbaligi", "pirinc", "kombuyosunu");
        sushiList.Add(unagiNigiri);
        Sushi sakeNigiri = new Sushi(SushiType.Nigiri, "cigsomon", "pirinc");
        sushiList.Add(sakeNigiri);
        Sushi hotateNigiri = new Sushi(SushiType.Nigiri, "tazecigdeniztaragi", "pirinc");
        sushiList.Add(hotateNigiri);
        Sushi maguroNigiri = new Sushi(SushiType.Nigiri, "cigtonbaligi", "pirinc");
        sushiList.Add(maguroNigiri);
        Sushi hosoMaki = new Sushi(SushiType.Maki, "pirinc", "nori", "salatalik");
        sushiList.Add(hosoMaki);
        Sushi nattoMaki = new Sushi(SushiType.Maki, "pirinc", "tazesogan", "fermentesoyafasulyesi", "yosun");
        sushiList.Add(nattoMaki);
        Sushi sakeMaki = new Sushi(SushiType.Maki, "pirinc", "yosun", "somon", "julyensalatalik");
        sushiList.Add(sakeMaki);
        Sushi tekkaMaki = new Sushi(SushiType.Maki, "pirinc", "yosun", "tonbaligi");


        return sushiList;
    }
}
