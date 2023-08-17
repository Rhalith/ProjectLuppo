using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text moneyText;

    private int _moneyAmount = 0;

    public delegate void MoneyDelegate(int moneyAmount);
    public event MoneyDelegate OnMoneyChanged;

    public static MoneyManager Instance;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public int GetMoney()
    {
        return _moneyAmount;
    }

    public void AddMoney(int moneyAmount)
    {
        if(moneyAmount > 0)
        {
            _moneyAmount += moneyAmount;

            // Instantiate Add money effect
            //
        }
        else
        {
            if (_moneyAmount - moneyAmount > 0)
            {
                _moneyAmount -= moneyAmount;
            }
            else
            {
                _moneyAmount = 0;
            }

            // Instantiate reduce money effect
            //
        }
        
        // Update money text
        moneyText.text = $"{_moneyAmount}$";

        // An event can be triggered about money change with ne money amount
        OnMoneyChanged?.Invoke(_moneyAmount);
    }
}
