using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerManager : MonoBehaviour
{
    #region SerializeFields
    [SerializeField] GameObject[] customerPrefabs;
    [SerializeField] GameObject spawnPoint;
    [SerializeField] GameObject turnPoint;
    [SerializeField] GameObject orderPoint;
    [SerializeField] Transform customersParentTransform;

    [SerializeField] int customerLimit = 1;
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
        _rotation.eulerAngles = new Vector3(0, -90, 0);

        // Add Customer
        StartCoroutine(SpawnNewCustomers());
    }

    #region Customer Spawn and Destroy
    private OrderedSushiType GiveOrder()
    {
        int orderNumber = Random.Range(0, 3);
        OrderedSushiType food = OrderedSushiType.CucumberHosomaki; ;

        if (orderNumber == 0)
        {
            food = OrderedSushiType.CucumberHosomaki;
        }
        else if (orderNumber == 1)
        {
            food = OrderedSushiType.SalmonHosomaki;
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
        return Instantiate(customerPref, new Vector3(_position.x + customerQueue.Count * 20, _position.y, _position.z + Random.Range(-5f, 5f)), _rotation, customersParentTransform);
    }

    // Customer spawner ve queue ba�tan yaz�lacak
    public IEnumerator SpawnNewCustomers()
    {
        while (customerQueue.Count < customerLimit)
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
        }
    }

    public void DequeueCustomer()
    {
        // S�rada en ba�ta olan eleman destroy edilir ve order Empty olarak ayarlan�r.
        Destroy(customerQueue.Dequeue().GetCustomerObj);
        OrderManager.Instance.EmptyOrder();
    }

    public IEnumerator SetNewOrder()
    {
        DequeueCustomer();
        // Bunun yerine event kullan�labilir.
        OrderManager.Instance.UpdateOrder(customerQueue.Peek().GetOrderedSushi);

        yield return new WaitForSeconds(2f);

        StartCoroutine(SpawnNewCustomers());
    }
    #endregion
}
