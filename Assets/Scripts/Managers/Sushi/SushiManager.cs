using System.Collections.Generic;
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    private static SushiManager _instance;
    private List<SushiIngredient> _availableIngredients = new();
    private List<Sushi> _availabeSushis = new();
    private List<Sushi> _createdSushis = new();

    public static SushiManager Instance { get => _instance; }
    public List<SushiIngredient> AvailableIngredients { get => _availableIngredients; set => _availableIngredients = value; }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
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
        Sushi sakeSashimi = new(SushiType.Sashimi,SushiIngredient.salmon); 
        sushiList.Add(sakeSashimi);
        Sushi ebiSashimi = new(SushiType.Sashimi, SushiIngredient.shrimp); 
        sushiList.Add(ebiSashimi);
        Sushi ahiSashimi = new(SushiType.Sashimi, SushiIngredient.rawtunafish, SushiIngredient.soysauce); 
        sushiList.Add(ahiSashimi);
        Sushi unagiSashimi = new(SushiType.Sashimi, SushiIngredient.freshwatereel, SushiIngredient.unagisauce); 
        sushiList.Add(unagiSashimi); 
        Sushi hamachiSashimi = new(SushiType.Sashimi, SushiIngredient.yellowtail, SushiIngredient.yuzu, SushiIngredient.soysauce); 
        sushiList.Add(hamachiSashimi);
        Sushi takoSashimi = new(SushiType.Sashimi, SushiIngredient.octopus);
        sushiList.Add(takoSashimi);
        #endregion
        #region Nigiri
        Sushi ebiNigiri = new(SushiType.Nigiri, SushiIngredient.shrimp, SushiIngredient.rice, SushiIngredient.kombuweed);
        sushiList.Add(ebiNigiri);
        Sushi tamagoNigiri = new(SushiType.Nigiri, SushiIngredient.omelette, SushiIngredient.kombuweed, SushiIngredient.rice);
        sushiList.Add(tamagoNigiri);
        Sushi unagiNigiri = new(SushiType.Nigiri, SushiIngredient.freshwatereel, SushiIngredient.rice, SushiIngredient.kombuweed);
        sushiList.Add(unagiNigiri);
        Sushi sakeNigiri = new(SushiType.Nigiri, SushiIngredient.salmon, SushiIngredient.rice);
        sushiList.Add(sakeNigiri);
        Sushi hotateNigiri = new(SushiType.Nigiri, SushiIngredient.rawoyster, SushiIngredient.rice);
        sushiList.Add(hotateNigiri);
        Sushi maguroNigiri = new(SushiType.Nigiri, SushiIngredient.rawtunafish, SushiIngredient.rice);
        sushiList.Add(maguroNigiri);
        #endregion
        #region Nori Maki (Makizushi)
        Sushi sakeHosomaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon);
        sushiList.Add(sakeHosomaki);
        Sushi tekkaMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish);
        sushiList.Add(tekkaMaki);
        Sushi kappaMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.juliennecucumber);
        sushiList.Add(kappaMaki);
        Sushi shinkoMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.julienneradish);
        sushiList.Add(shinkoMaki);
        Sushi oshinkoMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.juliennedaikon);
        sushiList.Add(oshinkoMaki);
        Sushi kanpyoMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.kanpyo);
        sushiList.Add(kanpyoMaki);
        Sushi ebiMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.shrimp);
        sushiList.Add(ebiMaki);
        Sushi tamagoMaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.omelette);
        sushiList.Add(tamagoMaki);
        Sushi unagiHosomaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.freshwatereel);
        sushiList.Add(unagiHosomaki);
        Sushi crabStickHosomaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.crabstick);
        sushiList.Add(crabStickHosomaki);
        Sushi avocadoHosomaki = new(SushiType.Hosomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.avocado);
        sushiList.Add(avocadoHosomaki);
        Sushi kappaPhilly = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.juliennecucumber, SushiIngredient.creamcheese);
        sushiList.Add(kappaPhilly);
        Sushi akanasuMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.tomatopesto, SushiIngredient.creamcheese);
        sushiList.Add(akanasuMaki);
        Sushi akanasuAvocadoMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.tomatopesto, SushiIngredient.creamcheese, SushiIngredient.avocado);
        sushiList.Add(akanasuAvocadoMaki);
        Sushi nattoMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.springonion, SushiIngredient.fermentedsoybean);
        sushiList.Add(nattoMaki);
        Sushi teriMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.teriyakichicken, SushiIngredient.juliennecucumber, SushiIngredient.juliennebellpepper);
        sushiList.Add(teriMaki);
        Sushi sakeChumaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.juliennecucumber);
        sushiList.Add(sakeChumaki);
        Sushi syakeMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.springonion);
        sushiList.Add(syakeMaki);
        Sushi umekyuMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.juliennecucumber, SushiIngredient.plum);
        sushiList.Add(umekyuMaki);
        Sushi unakyuMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.freshwatereel, SushiIngredient.juliennecucumber, SushiIngredient.avocado);
        sushiList.Add(unakyuMaki);
        Sushi negitoroMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.springonion);
        sushiList.Add(negitoroMaki);
        Sushi negihamaMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.yellowtail, SushiIngredient.springonion);
        sushiList.Add(negihamaMaki);
        Sushi umeshisoMaki = new(SushiType.Chumaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.plum, SushiIngredient.freshshisoleaves);
        sushiList.Add(umeshisoMaki);
        Sushi tekkaTempuraMaki = new(SushiType.Futomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.springonion, SushiIngredient.tempura, SushiIngredient.spicymayonnaise, SushiIngredient.spicysauce);
        sushiList.Add(tekkaTempuraMaki);
        Sushi syakeTempuraMaki = new(SushiType.Futomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.springonion, SushiIngredient.tempura, SushiIngredient.spicymayonnaise, SushiIngredient.spicysauce);
        sushiList.Add(syakeTempuraMaki);
        Sushi veggieFutomaki = new(SushiType.Futomaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.juliennecucumber, SushiIngredient.juliennebellpepper, SushiIngredient.plum, SushiIngredient.avocado, SushiIngredient.mango);
        sushiList.Add(veggieFutomaki);
        #endregion
        #region Uramaki
        Sushi californiaRoll = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.juliennecucumber, SushiIngredient.avocado, SushiIngredient.crabstick, SushiIngredient.seaweed, SushiIngredient.caviar);
        sushiList.Add(californiaRoll);
        Sushi rainbowRollTon = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.avocado, SushiIngredient.crabstick, SushiIngredient.juliennecucumber);
        sushiList.Add(rainbowRollTon);
        Sushi rainbowRollSarikuyruk = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.yellowtail, SushiIngredient.avocado, SushiIngredient.crabstick, SushiIngredient.juliennecucumber);
        sushiList.Add(rainbowRollSarikuyruk);
        Sushi rainbowRollSomon = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.avocado, SushiIngredient.crabstick, SushiIngredient.juliennecucumber);
        sushiList.Add(rainbowRollSomon);
        Sushi dragonRoll = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.avocado, SushiIngredient.juliennecucumber, SushiIngredient.freshwatereel, SushiIngredient.shrimp);
        sushiList.Add(dragonRoll);
        Sushi spicyTunaRoll = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.sriracha, SushiIngredient.sesameoil, SushiIngredient.spicymayonnaise);
        sushiList.Add(spicyTunaRoll);
        #endregion
        #region Temaki
        //Empty for now
        #endregion
        #region Gunkan Maki
        //Empty for now
        #endregion
        

        return sushiList;
    }

    #region Used Ingredient Zone
    //Bu kýsým kontrol edilip uygun bir kod olup olmadýðý belirtilecek.
    //TODO: IngredientManager adýnda yeni bir scripte taþýnacak.
    
    
    private List<SushiIngredient> _usedIngredients = new List<SushiIngredient>();

    public void AddIngredientToSushi(SushiIngredient ingredient)
    {
        _usedIngredients.Add(ingredient);
    }

    public void RemoveIngredientFromSushi(SushiIngredient ingredient)
    {
        _usedIngredients.Remove(ingredient);
    }

    public void ClearUsedIngredients()
    {
        _usedIngredients.Clear();
    }
    #endregion
}
