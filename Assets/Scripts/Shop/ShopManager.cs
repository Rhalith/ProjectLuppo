using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject _meatMenu, _vegetablesMenu, _sidedishesMenu, _otherMenu;


    [SerializeField] private SushiManager _sushiManager;
    [SerializeField] private PlayerData _playerData;

    public float PlayerMoney => _playerData.Money;

    public void BuyIngredient(SushiIngredient sushiIngredient, float price)
    {
         _sushiManager.AddIngredient(sushiIngredient);
         _playerData.RemoveMoney(price);
    }

    public void ChangeMenu(GameObject gameObject)
    {
        if(gameObject == _meatMenu)
        {
            _meatMenu.SetActive(true);
            _vegetablesMenu.SetActive(false);
            _sidedishesMenu.SetActive(false);
            _otherMenu.SetActive(false);
        }
        else if (gameObject == _vegetablesMenu)
        {
            _meatMenu.SetActive(false);
            _vegetablesMenu.SetActive(true);
            _sidedishesMenu.SetActive(false);
            _otherMenu.SetActive(false);
        }
        else if (gameObject == _sidedishesMenu)
        {
            _meatMenu.SetActive(false);
            _vegetablesMenu.SetActive(false);
            _sidedishesMenu.SetActive(true);
            _otherMenu.SetActive(false);
        }
        else if (gameObject == _otherMenu)
        {
            _meatMenu.SetActive(false);
            _vegetablesMenu.SetActive(false);
            _sidedishesMenu.SetActive(false);
            _otherMenu.SetActive(true);
        }
    }
}
