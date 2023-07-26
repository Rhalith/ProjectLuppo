using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private float _money;

    public float Money { get => _money; }

    [SerializeField] private TMP_Text _moneyText;

    private void Start()
    {
        _money = 500;
    }
    public void AddMoney(float amount)
    {
        _money += amount;
        UpdateUI();
    }

    public void RemoveMoney(float amount)
    {
        if(_money == 0)
        {
            Debug.Log("You don't have enough money");
            return;
        }
        _money -= amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        _moneyText.text = "$"+_money.ToString();
    }
}
