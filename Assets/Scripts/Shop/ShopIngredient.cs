using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopIngredient : MonoBehaviour
{
    [SerializeField] private SushiIngredient _ingredient;
    [SerializeField] private float _price;
    [SerializeField] private Button _button;
    [SerializeField] private Color _color;
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _priceText;
    [SerializeField] private ShopManager _shopManager;
    public void BuyIngredient()
    {
        if(_shopManager.PlayerMoney >= _price)
        {
            _shopManager.BuyIngredient(_ingredient, _price);
            MakeIngredientOpened();
        }
    }

    private void MakeIngredientOpened()
    {
        _button.interactable = false;
        _image.color = _color;
        _priceText.text = "$$$";
    }
}
