using Cinemachine;
using UnityEngine;

public class VCamFollower : MonoBehaviour
{
    [SerializeField] private GameObject kitchenLookAtPoint;
    [SerializeField] private GameObject customerLookAtPoint;

    private CinemachineVirtualCamera _vcam;

    private void Start()
    {
        GameEventsManager.Instance.OnReturnToKitchen += OnReturnToKitchen;
        GameEventsManager.Instance.OnReturnToCustomer += OnReturnToCustomer;
        GameEventsManager.Instance.OnOrderServed += OnOrderServed;

        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnDestroy()
    {
        GameEventsManager.Instance.OnReturnToKitchen -= OnReturnToKitchen;
        GameEventsManager.Instance.OnReturnToCustomer -= OnReturnToCustomer;
        GameEventsManager.Instance.OnOrderServed -= OnOrderServed;
    }

    void OnReturnToKitchen()
    {
        _vcam.LookAt = kitchenLookAtPoint.transform;
    }

    private void OnReturnToCustomer()
    {
        _vcam.LookAt = customerLookAtPoint.transform;
    }

    void OnOrderServed()
    {
        _vcam.LookAt = customerLookAtPoint.transform;
    }
}
