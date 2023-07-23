using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    private static SushiManager _instance;
    private List<SushiIngredient> _availableIngredients = new();
    private List<Sushi> _availabeSushis = new();
    private List<Sushi> _createdSushis = new();

    public List<SushiIngredient> AvailableIngredients { get => _availableIngredients; set => _availableIngredients = value; }

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

    private void Start()
    {
        _createdSushis = CreateSushis();
    }

    public void AddIngredient(SushiIngredient ingredient)
    {
        _availableIngredients.Add(ingredient);
    }

    public void CheckAvailableSushis()
    {
        foreach (Sushi sushi in _createdSushis)
        {
            if (sushi.CheckIngredients(_availableIngredients))
            {
                _availabeSushis.Add(sushi);
                _createdSushis.Remove(sushi);
            }
        }
    }

    List<Sushi> CreateSushis()
    {
        List<Sushi> sushiList = new ();

        #region Sashimi
        Sushi sake = new Sushi(SushiType.Sashimi,SushiIngredient.somon); 
        sushiList.Add(sake);
        Sushi ebi = new Sushi(SushiType.Sashimi, SushiIngredient.karides); 
        sushiList.Add(ebi);
        Sushi ahi = new Sushi(SushiType.Sashimi, SushiIngredient.cigtonbaligi, SushiIngredient.soyasosu); 
        sushiList.Add(ahi);
        Sushi unagi = new Sushi(SushiType.Sashimi, SushiIngredient.tatlisuyyilanbaligi, SushiIngredient.unagisosu); 
        sushiList.Add(unagi); 
        Sushi hamachi = new Sushi(SushiType.Sashimi, SushiIngredient.sarikuyruk, SushiIngredient.yuzu, SushiIngredient.soyasosu); 
        sushiList.Add(hamachi);
        Sushi tako = new Sushi(SushiType.Sashimi, SushiIngredient.ahtapot);
        sushiList.Add(tako);
        #endregion
        #region Nigiri
        Sushi ebiNigiri = new Sushi(SushiType.Nigiri, SushiIngredient.karides, SushiIngredient.pirinc, SushiIngredient.kombuyosunu);
        sushiList.Add(ebiNigiri);
        Sushi tamagoNigiri = new Sushi(SushiType.Nigiri, SushiIngredient.omlet, SushiIngredient.kombuyosunu, SushiIngredient.pirinc);
        sushiList.Add(tamagoNigiri);
        Sushi unagiNigiri = new Sushi(SushiType.Nigiri, SushiIngredient.tatlisuyyilanbaligi, SushiIngredient.pirinc, SushiIngredient.kombuyosunu);
        sushiList.Add(unagiNigiri);
        Sushi sakeNigiri = new Sushi(SushiType.Nigiri, SushiIngredient.somon, SushiIngredient.pirinc);
        sushiList.Add(sakeNigiri);
        Sushi hotateNigiri = new Sushi(SushiType.Nigiri, SushiIngredient.tazedcigdeniztaragi, SushiIngredient.pirinc);
        sushiList.Add(hotateNigiri);
        Sushi maguroNigiri = new Sushi(SushiType.Nigiri, SushiIngredient.cigtonbaligi, SushiIngredient.pirinc);
        sushiList.Add(maguroNigiri);
        #endregion
        #region Maki
        Sushi hosoMaki = new Sushi(SushiType.Maki, SushiIngredient.omlet, SushiIngredient.kombuyosunu, SushiIngredient.salatalik);
        sushiList.Add(hosoMaki);
        Sushi nattoMaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.tazesogan, SushiIngredient.fermentesoyafasulyesi, SushiIngredient.yosun);
        sushiList.Add(nattoMaki);
        Sushi sakeMaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.somon, SushiIngredient.julyensalatalik);
        sushiList.Add(sakeMaki);
        Sushi tekkaMaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi);
        sushiList.Add(tekkaMaki);
        Sushi kappaMaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi);
        sushiList.Add(kappaMaki);
        Sushi shinkoMaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.julyenturp);
        sushiList.Add(shinkoMaki);
        Sushi kanpyoMaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.soyasosu, SushiIngredient.kanpyo);
        sushiList.Add(kanpyoMaki);
        Sushi chumaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.nori, SushiIngredient.julyensalatalik, SushiIngredient.avokado, SushiIngredient.omlet);
        sushiList.Add(chumaki);
        //ask to burak about somon/ton realation
        Sushi futomaki = new Sushi(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.somon, SushiIngredient.cigtonbaligi, SushiIngredient.havuc);
        sushiList.Add(futomaki);
        #endregion
        #region Uramaki
        Sushi californiaRoll = new Sushi(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.julyensalatalik, SushiIngredient.avokado, SushiIngredient.yengeceti, SushiIngredient.yosun, SushiIngredient.havyar);
        sushiList.Add(californiaRoll);
        //ask burak about ton/sarikuyruk/somon relation
        Sushi rainbowRoll = new Sushi(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi, SushiIngredient.avokado, SushiIngredient.yengeceti, SushiIngredient.julyensalatalik);
        sushiList.Add(rainbowRoll);
        Sushi dragonRoll = new Sushi(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.avokado, SushiIngredient.julyensalatalik, SushiIngredient.tatlisuyyilanbaligi, SushiIngredient.karides);
        sushiList.Add(dragonRoll);
        Sushi spicyTunaRoll = new Sushi(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi, SushiIngredient.sriracha, SushiIngredient.susamyagi, SushiIngredient.baharatlimayonez);
        #endregion

        return sushiList;
    }
}
