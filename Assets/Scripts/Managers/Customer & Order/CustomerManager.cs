using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// GetFoodName metodu ile ayr� bir yere ta��nabilirler.
public enum OrderedSushiType
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
    
    // Customer Queue FIFO
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
        // �u anl�k Customer'lar direkt kar��m�zda spawnlans�n diye varlar.
        _position = orderPoint.transform.position;
        _rotation.eulerAngles = new Vector3(0, 0, 0);

        StartCoroutine(SpawnNewCustomers());

        GameEventsManager.Instance.OnServingAdded += OnServingAdded;
    }

    #region Get Name With enum
    public string GetFoodName(OrderedSushiType orderedSushi)
    {
        string sushiName = "Somon Salatal�k Chumaki";

        if (orderedSushi == OrderedSushiType.CucumberHosomaki)
        {
            sushiName = "Salatal�k Hosomaki";
        }
        else if (orderedSushi == OrderedSushiType.SalmonHosomaki)
        {
            sushiName = "Somon Hosomaki";
        }
        else if (orderedSushi == OrderedSushiType.SalmonCucumberChumaki)
        {
            sushiName = "Somon Salatal�k Chumaki";
        }

        return sushiName;
    }
    #endregion
    //TODO: All of them salmoncucumberchumaki right now for testing.
    private OrderedSushiType GiveOrder()
    {
        int orderNumber = Random.Range(0, 3);
        OrderedSushiType food = OrderedSushiType.CucumberHosomaki; ;

        if (orderNumber == 0)
        {
            food = OrderedSushiType.SalmonCucumberChumaki;
        }
        else if (orderNumber == 1)
        {
            food = OrderedSushiType.SalmonCucumberChumaki;
        }
        else if (orderNumber == 2)
        {
            food = OrderedSushiType.SalmonCucumberChumaki;
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

    // Customer spawner ve queue ba�tan yaz�lacak
    public IEnumerator SpawnNewCustomers()
    {
        while(customerQueue.Count < customerLimit)
        {
            // Fonksiyon isimleri d�zenlenebilir.
            GameObject customerObj = CustomerInstantiate();
            OrderedSushiType sushi = GiveOrder();

            Customer customer = new Customer(customerObj, sushi);
            customerQueue.Enqueue(customer);

            // Bunun yerine event kullan�labilir.
            OrderManager.Instance.UpdateOrder(customerQueue.Peek().GetOrderedSushi);

            // Wait for a random time
            yield return new WaitForSeconds(Random.Range(1.5f, 5f));

            // Customer diyalog'u buradan ayr� olmal�. 
            // customerText.text = "Selamlar, ben bir adet " + GetFoodName(sushi) + " alabilir miyim?";
        }
    }

    IEnumerator DestroyCustomer()
    {
        // S�rada en ba�ta olan eleman destroy edilir ve order Empty olarak ayarlan�r.
        Destroy(customerQueue.Dequeue().GetCustomerObj);
        OrderManager.Instance.EmptyOrder();

        // Bunun yerine event kullan�labilir.
        OrderManager.Instance.UpdateOrder(customerQueue.Peek().GetOrderedSushi);

        yield return new WaitForSeconds(2f);


        // Coroutine'ler tamamlan�nca temizleniyorlar m�???
        //if(_spawnCustomerCoroutine == null)

        StartCoroutine(SpawnNewCustomers());
    }

    void OnServingAdded()
    {
        StartCoroutine(DestroyCustomer());
    }


    #endregion

    #region SushiMechanic



    #endregion
}
