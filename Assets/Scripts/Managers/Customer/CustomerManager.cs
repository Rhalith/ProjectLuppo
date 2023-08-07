using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomerManager : MonoBehaviour
{
    #region Customer Creation

    [SerializeField] GameObject[] _customerPrefabs;
    GameObject _currentCustomer;
    GameObject _instCustomer;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _turnPoint;
    [SerializeField] GameObject _orderPoint;
    Vector3 _position;
    Quaternion _rotation;
    private int _score;
    private string[] _wantedMaterials;
    private int _orderNumber;
    WantedFoods _wantedSushi;
    public string _sushiName;
    [SerializeField] TextMeshProUGUI _customerText;
    [SerializeField] GameObject CustomerUI;

    enum WantedFoods
    {
        SalmonHosomaki,
        CucumberHosomaki,
        SalmonCucumberChumaki,
    }

    private void Start()
    {
        //_spawnPoint = GetComponent<GameObject>();
        //_turnPoint = GetComponent<GameObject>();
        //_orderPoint = GetComponent<GameObject>();
        _position = _orderPoint.transform.position;
        _rotation.eulerAngles = new Vector3(0, 0, 0);
        
        _wantedSushi = WantedFoods.SalmonHosomaki;

        StartCoroutine(SpawnNewCustomer());

        GameEventsManager.instance.OnServingAdded += OnServingAdded;

    }

    WantedFoods GiveOrder()
    {
        if (_orderNumber == 0)
        {
            _wantedSushi = WantedFoods.CucumberHosomaki;
            _sushiName = "Salatalýk Hosomaki";
        }
        else if (_orderNumber == 1)
        {
            _wantedSushi = WantedFoods.SalmonHosomaki;
            _sushiName = "Somon Hosomaki";
        }

        else if (_orderNumber == 2)
        {
            _wantedSushi = WantedFoods.SalmonCucumberChumaki;
            _sushiName = "Somon Salatalýk Chumaki";
        }

        return _wantedSushi;
    }

    private void CustomerInstantiate()
    {
        _orderNumber = Random.Range(0, 3);
        _currentCustomer = _customerPrefabs[Random.Range(0, 4)];
        _instCustomer = Instantiate(_currentCustomer, _position, _rotation);
        _instCustomer.tag = "Customer";
    }
    #endregion

    #region SushiMechanic



    #endregion


    #region CustomerMovement

    //TODO: movement system. can instantly instantiate for tomorrow.

    public IEnumerator SpawnNewCustomer()
    {
        CustomerInstantiate();
        yield return new WaitForSeconds(1.5f);
        GiveOrder();
        _customerText.text = "Selamlar, ben bir adet " + _sushiName + " alabilir miyim?";
    }

    IEnumerator DestroyCustomer()
    {
        yield return new WaitForSeconds(3f);
        GameObject[] a;
        a = GameObject.FindGameObjectsWithTag("Customer");
        foreach (GameObject go in a) { Destroy(go); }
        yield return new WaitForSeconds(2f);
        StartCoroutine(SpawnNewCustomer());
    }

    void OnServingAdded()
    {
        StartCoroutine(DestroyCustomer());
    }


    #endregion
}
