using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// GetFoodName metodu ile ayrý bir yere taþýnabilirler.
public enum OrderSushiType
{
    Empty,
    SalmonHosomaki,
    CucumberHosomaki,
    SalmonCucumberChumaki,
}

public class CustomerManager : MonoBehaviour
{
    #region Customer Creation
    #region SerializeFields
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject turnPoint;
    [SerializeField] GameObject orderPoint;
    [SerializeField] TextMeshProUGUI customerText;
    [SerializeField] GameObject customerUI;
    [SerializeField] Transform customersParentTransform;

    [SerializeField] int customerLimit = 5;
    #endregion

    private Vector3 _position;
    private Quaternion _rotation;

    // Customer Tipine çevrilecek.
    public Queue<Customer> customerQueue = new Queue<Customer>();

    public static CustomerManager Instance;

    private void Awake()
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

    private void Start()
    {
        // Þu anlýk Customer'lar direkt karþýmýzda spawnlansýn diye varlar.
        _position = orderPoint.transform.position;
        _rotation.eulerAngles = new Vector3(0, 0, 0);

        StartCoroutine(SpawnNewCustomers());

        GameEventsManager.instance.OnServingAdded += OnServingAdded;
    }

    #region Get Name With enum
    public string GetFoodName(OrderSushiType orderedSushi)
    {
        string sushiName = "Somon Salatalýk Chumaki";

        if (orderedSushi == OrderSushiType.CucumberHosomaki)
        {
            sushiName = "Salatalýk Hosomaki";
        }
        else if (orderedSushi == OrderSushiType.SalmonHosomaki)
        {
            sushiName = "Somon Hosomaki";
        }
        else if (orderedSushi == OrderSushiType.SalmonCucumberChumaki)
        {
            sushiName = "Somon Salatalýk Chumaki";
        }

        return sushiName;
    }
    #endregion

    private OrderSushiType GiveOrder()
    {
        int orderNumber = Random.Range(0, 3);
        OrderSushiType food = OrderSushiType.CucumberHosomaki; ;

        if (orderNumber == 0)
        {
            food = OrderSushiType.CucumberHosomaki;
        }
        else if (orderNumber == 1)
        {
            food = OrderSushiType.SalmonHosomaki;
        }
        else if (orderNumber == 2)
        {
            food = OrderSushiType.SalmonCucumberChumaki;
        }

        return food;
    }

    private GameObject CustomerInstantiate()
    {
        GameObject customerPref = customerPrefabs[Random.Range(0, 3)];
        return Instantiate(customerPref, _position, _rotation, customersParentTransform);
    }
    #endregion

    #region Customer Ordering

    // Customer spawner ve queue baþtan yazýlacak
    public IEnumerator SpawnNewCustomers()
    {
        while(customerQueue.Count < customerLimit)
        {
            // Fonksiyon isimleri düzenlenebilir.
            GameObject customerObj = CustomerInstantiate();
            OrderSushiType sushi = GiveOrder();

            Customer customer = new Customer(customerObj, sushi);
            customerQueue.Enqueue(customer);

            // Bunun yerine event kullanýlabilir.
            OrderManager.Instance.UpdateOrder(customerQueue.Peek().GetOrderedSushi);

            // Wait for a random time
            yield return new WaitForSeconds(Random.Range(1.5f, 5f));

            // Customer diyalog'u buradan ayrý olmalý. 
            // customerText.text = "Selamlar, ben bir adet " + GetFoodName(sushi) + " alabilir miyim?";
        }
    }

    IEnumerator DestroyCustomer()
    {
        // Sýrada en baþta olan eleman destroy edilir.
        Destroy(customerQueue.Dequeue().GetCustomerObj);
        OrderManager.Instance.EmptyOrder();

        // Bunun yerine event kullanýlabilir.
        OrderManager.Instance.UpdateOrder(customerQueue.Peek().GetOrderedSushi);

        yield return new WaitForSeconds(2f);


        // Coroutine'ler tamamlanýnca temizleniyorlar mý???
        //if(_spawnCustomerCoroutine == null)

        _spawnCustomerCoroutine = StartCoroutine(SpawnNewCustomers());
    }

    void OnServingAdded()
    {
        StartCoroutine(DestroyCustomer());
    }


    #endregion

    #region SushiMechanic



    #endregion
}
