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
        Sushi sake = new(SushiType.Sashimi,SushiIngredient.somon); 
        sushiList.Add(sake);
        Sushi ebi = new(SushiType.Sashimi, SushiIngredient.karides); 
        sushiList.Add(ebi);
        Sushi ahi = new(SushiType.Sashimi, SushiIngredient.cigtonbaligi, SushiIngredient.soyasosu); 
        sushiList.Add(ahi);
        Sushi unagi = new(SushiType.Sashimi, SushiIngredient.tatlisuyyilanbaligi, SushiIngredient.unagisosu); 
        sushiList.Add(unagi); 
        Sushi hamachi = new(SushiType.Sashimi, SushiIngredient.sarikuyruk, SushiIngredient.yuzu, SushiIngredient.soyasosu); 
        sushiList.Add(hamachi);
        Sushi tako = new(SushiType.Sashimi, SushiIngredient.ahtapot);
        sushiList.Add(tako);
        #endregion
        #region Nigiri
        Sushi ebiNigiri = new(SushiType.Nigiri, SushiIngredient.karides, SushiIngredient.pirinc, SushiIngredient.kombuyosunu);
        sushiList.Add(ebiNigiri);
        Sushi tamagoNigiri = new(SushiType.Nigiri, SushiIngredient.omlet, SushiIngredient.kombuyosunu, SushiIngredient.pirinc);
        sushiList.Add(tamagoNigiri);
        Sushi unagiNigiri = new(SushiType.Nigiri, SushiIngredient.tatlisuyyilanbaligi, SushiIngredient.pirinc, SushiIngredient.kombuyosunu);
        sushiList.Add(unagiNigiri);
        Sushi sakeNigiri = new(SushiType.Nigiri, SushiIngredient.somon, SushiIngredient.pirinc);
        sushiList.Add(sakeNigiri);
        Sushi hotateNigiri = new(SushiType.Nigiri, SushiIngredient.tazecigdeniztaragi, SushiIngredient.pirinc);
        sushiList.Add(hotateNigiri);
        Sushi maguroNigiri = new(SushiType.Nigiri, SushiIngredient.cigtonbaligi, SushiIngredient.pirinc);
        sushiList.Add(maguroNigiri);
        #endregion
        #region Maki
        Sushi hosoMaki = new(SushiType.Maki, SushiIngredient.omlet, SushiIngredient.kombuyosunu, SushiIngredient.salatalik);
        sushiList.Add(hosoMaki);
        Sushi nattoMaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.tazesogan, SushiIngredient.fermentesoyafasulyesi, SushiIngredient.yosun);
        sushiList.Add(nattoMaki);
        Sushi sakeMaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.somon, SushiIngredient.julyensalatalik);
        sushiList.Add(sakeMaki);
        Sushi tekkaMaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi);
        sushiList.Add(tekkaMaki);
        Sushi kappaMaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi);
        sushiList.Add(kappaMaki);
        Sushi shinkoMaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.julyenturp);
        sushiList.Add(shinkoMaki);
        Sushi kanpyoMaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.soyasosu, SushiIngredient.kanpyo);
        sushiList.Add(kanpyoMaki);
        Sushi chumaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.nori, SushiIngredient.julyensalatalik, SushiIngredient.avokado, SushiIngredient.omlet);
        sushiList.Add(chumaki);
        Sushi futomakiSomon = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.somon, SushiIngredient.havuc);
        sushiList.Add(futomakiSomon);
        Sushi futomakiTon = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi, SushiIngredient.havuc);
        sushiList.Add(futomakiTon);
        Sushi futomaki = new(SushiType.Maki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi, SushiIngredient.somon, SushiIngredient.havuc);
        sushiList.Add(futomaki);
        #endregion
        #region Uramaki
        Sushi californiaRoll = new(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.julyensalatalik, SushiIngredient.avokado, SushiIngredient.yengeceti, SushiIngredient.yosun, SushiIngredient.havyar);
        sushiList.Add(californiaRoll);
        Sushi rainbowRollTon = new(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi, SushiIngredient.avokado, SushiIngredient.yengeceti, SushiIngredient.julyensalatalik);
        sushiList.Add(rainbowRollTon);
        Sushi rainbowRollSarikuyruk = new(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.sarikuyruk, SushiIngredient.avokado, SushiIngredient.yengeceti, SushiIngredient.julyensalatalik);
        sushiList.Add(rainbowRollSarikuyruk);
        Sushi rainbowRollSomon = new(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.somon, SushiIngredient.avokado, SushiIngredient.yengeceti, SushiIngredient.julyensalatalik);
        sushiList.Add(rainbowRollSomon);
        Sushi dragonRoll = new(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.avokado, SushiIngredient.julyensalatalik, SushiIngredient.tatlisuyyilanbaligi, SushiIngredient.karides);
        sushiList.Add(dragonRoll);
        Sushi spicyTunaRoll = new(SushiType.Uramaki, SushiIngredient.pirinc, SushiIngredient.yosun, SushiIngredient.cigtonbaligi, SushiIngredient.sriracha, SushiIngredient.susamyagi, SushiIngredient.baharatlimayonez);
        sushiList.Add(spicyTunaRoll);
        #endregion

        return sushiList;
    }
}
