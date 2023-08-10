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
        Sushi sake = new(SushiType.Sashimi,SushiIngredient.salmon); 
        sushiList.Add(sake);
        Sushi ebi = new(SushiType.Sashimi, SushiIngredient.shrimp); 
        sushiList.Add(ebi);
        Sushi ahi = new(SushiType.Sashimi, SushiIngredient.rawtunafish, SushiIngredient.soysauce); 
        sushiList.Add(ahi);
        Sushi unagi = new(SushiType.Sashimi, SushiIngredient.freshwatereel, SushiIngredient.unagisauce); 
        sushiList.Add(unagi); 
        Sushi hamachi = new(SushiType.Sashimi, SushiIngredient.yellowtail, SushiIngredient.yuzu, SushiIngredient.soysauce); 
        sushiList.Add(hamachi);
        Sushi tako = new(SushiType.Sashimi, SushiIngredient.octopus);
        sushiList.Add(tako);
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
        #region Maki
        Sushi hosoMaki = new(SushiType.Maki, SushiIngredient.omelette, SushiIngredient.kombuweed, SushiIngredient.cucumber);
        sushiList.Add(hosoMaki);
        Sushi nattoMaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.springonion, SushiIngredient.fermentedsoybean, SushiIngredient.seaweed);
        sushiList.Add(nattoMaki);
        Sushi sakeMaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.juliennecucumber);
        sushiList.Add(sakeMaki);
        Sushi tekkaMaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish);
        sushiList.Add(tekkaMaki);
        Sushi kappaMaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish);
        sushiList.Add(kappaMaki);
        Sushi shinkoMaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.julienneradish);
        sushiList.Add(shinkoMaki);
        Sushi kanpyoMaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.soysauce, SushiIngredient.kanpyo);
        sushiList.Add(kanpyoMaki);
        Sushi chumaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.nori, SushiIngredient.juliennecucumber, SushiIngredient.avocado, SushiIngredient.omelette);
        sushiList.Add(chumaki);
        Sushi futomakiSomon = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.carrot);
        sushiList.Add(futomakiSomon);
        Sushi futomakiTon = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.carrot);
        sushiList.Add(futomakiTon);
        Sushi futomaki = new(SushiType.Maki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.salmon, SushiIngredient.carrot);
        sushiList.Add(futomaki);
        #endregion
        #region Uramaki
        Sushi californiaRoll = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.juliennecucumber, SushiIngredient.avocado, SushiIngredient.crabmeat, SushiIngredient.seaweed, SushiIngredient.caviar);
        sushiList.Add(californiaRoll);
        Sushi rainbowRollTon = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.avocado, SushiIngredient.crabmeat, SushiIngredient.juliennecucumber);
        sushiList.Add(rainbowRollTon);
        Sushi rainbowRollSarikuyruk = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.yellowtail, SushiIngredient.avocado, SushiIngredient.crabmeat, SushiIngredient.juliennecucumber);
        sushiList.Add(rainbowRollSarikuyruk);
        Sushi rainbowRollSomon = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.salmon, SushiIngredient.avocado, SushiIngredient.crabmeat, SushiIngredient.juliennecucumber);
        sushiList.Add(rainbowRollSomon);
        Sushi dragonRoll = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.avocado, SushiIngredient.juliennecucumber, SushiIngredient.freshwatereel, SushiIngredient.shrimp);
        sushiList.Add(dragonRoll);
        Sushi spicyTunaRoll = new(SushiType.Uramaki, SushiIngredient.rice, SushiIngredient.seaweed, SushiIngredient.rawtunafish, SushiIngredient.sriracha, SushiIngredient.sesameoil, SushiIngredient.spicymayonnaise);
        sushiList.Add(spicyTunaRoll);
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
