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

    private void Start()
    {
        //_spawnPoint = GetComponent<GameObject>();
        //_turnPoint = GetComponent<GameObject>();
        //_orderPoint = GetComponent<GameObject>();
        _position = _spawnPoint.transform.position;
        _rotation.eulerAngles = new Vector3(0, 90f, 0);

        CustomerInstantiate();

    }

    private void CustomerInstantiate()
    {
        _currentCustomer = _customerPrefabs[Random.Range(0, 3)];
        Instantiate(_currentCustomer, _position, _rotation);
    }
    #endregion

    #region CustomerMovement

    //TODO: movement system. can instantly instantiate for tomorrow.

    #endregion
}
