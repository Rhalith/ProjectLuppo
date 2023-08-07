using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// GetFoodName metodu ile ayrý bir yere taþýnabilirler.
public enum WantedSushi
{
    SalmonHosomaki,
    CucumberHosomaki,
    SalmonCucumberChumaki,
}

public class CustomerManager : MonoBehaviour
{
    #region Customer Creation
    #region SerializeFields
    [SerializeField] GameObject[] _customerPrefabs;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _turnPoint;
    [SerializeField] GameObject _orderPoint;
    [SerializeField] TextMeshProUGUI _customerText;
    [SerializeField] GameObject CustomerUI;
    #endregion

    // Customer Tipine çevrilecek.
    Queue<Customer> customers = new Queue<Customer>();

    Vector3 _position;
    Quaternion _rotation;

    #region Get Name With enum
    public string GetFoodName(WantedSushi food)
    {
        string sushiName = "Somon Salatalýk Chumaki";

        if (food == WantedSushi.CucumberHosomaki)
        {
            sushiName = "Salatalýk Hosomaki";
        }
        else if (food == WantedSushi.SalmonHosomaki)
        {
            sushiName = "Somon Hosomaki";
        }
        else if (food == WantedSushi.SalmonCucumberChumaki)
        {
            sushiName = "Somon Salatalýk Chumaki";
        }

        return sushiName;
    }
    #endregion

    private void Start()
    {
        // Þu anlýk Customer'lar direkt karþýmýzda spawnlansýn diye varlar.
        _position = _orderPoint.transform.position;
        _rotation.eulerAngles = new Vector3(0, 0, 0);

        StartCoroutine(SpawnNewCustomer());

        GameEventsManager.instance.OnServingAdded += OnServingAdded;
    }

    private WantedSushi GiveOrder()
    {
        int orderNumber = Random.Range(0, 3);
        WantedSushi food = WantedSushi.CucumberHosomaki; ;

        if (orderNumber == 0)
        {
            food = WantedSushi.CucumberHosomaki;
        }
        else if (orderNumber == 1)
        {
            food = WantedSushi.SalmonHosomaki;
        }
        else if (orderNumber == 2)
        {
            food = WantedSushi.SalmonCucumberChumaki;
        }

        return food;
    }

    private GameObject CustomerInstantiate()
    {
        GameObject customerPref = _customerPrefabs[Random.Range(0, 3)];
        return Instantiate(customerPref, _position, _rotation);
    }
    #endregion

    #region Customer Ordering

    //TODO: movement system. can instantly instantiate for tomorrow.
    public IEnumerator SpawnNewCustomer()
    {
        // Fonksiyon isimleri düzenlenebilir.
        GameObject customerObj = CustomerInstantiate();
        WantedSushi sushi = GiveOrder();

        Customer customer = new Customer(customerObj, sushi);
        customers.Enqueue(customer);

        yield return new WaitForSeconds(1.5f);
        _customerText.text = "Selamlar, ben bir adet " + GetFoodName(sushi) + " alabilir miyim?";
    }

    IEnumerator DestroyCustomer()
    {
        yield return new WaitForSeconds(3f);

        // Sýrada en baþta olan eleman destroy edilir.
        Destroy(customers.Dequeue().GetCustomerObj);

        yield return new WaitForSeconds(2f);
    }

    void OnServingAdded()
    {
        StartCoroutine(DestroyCustomer());
    }


    #endregion

    #region SushiMechanic



    #endregion
}
