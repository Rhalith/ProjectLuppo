using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    #region Customer Creation

    [SerializeField] GameObject[] _customerPrefabs;
    GameObject _currentCustomer;
    [SerializeField] GameObject _spawnPoint;
    [SerializeField] GameObject _turnPoint;
    [SerializeField] GameObject _orderPoint;
    Vector3 _position;
    Quaternion _rotation;
    private int _score;
    private string[] _wantedMaterials;
    private int orderNumber;
    WantedFoods wantedSushi;

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
        
        wantedSushi = WantedFoods.SalmonHosomaki;

        

    }

    WantedFoods GiveOrder()
    {
        if (orderNumber == 0)
        {
            wantedSushi = WantedFoods.CucumberHosomaki;
        }
        else if (orderNumber == 1)
        {
            wantedSushi = WantedFoods.SalmonHosomaki;
        }

        else if (orderNumber == 2)
        {
            wantedSushi = WantedFoods.SalmonCucumberChumaki;
        }

        return wantedSushi;
    }

    private void CustomerInstantiate()
    {
        orderNumber = Random.Range(0, 3);
        _currentCustomer = _customerPrefabs[Random.Range(0, 3)];
        Instantiate(_currentCustomer, _position, _rotation);
    }
    #endregion

    #region SushiMechanic



    #endregion


    #region CustomerMovement

    //TODO: movement system. can instantly instantiate for tomorrow.

    IEnumerator SpawnNewCustomer()
    {
        CustomerInstantiate();
        yield return new WaitForSeconds(1.5f);
        GiveOrder();

    }

    #endregion
}
