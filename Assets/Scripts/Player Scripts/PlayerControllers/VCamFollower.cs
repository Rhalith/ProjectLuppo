using Cinemachine;
using UnityEngine;

public class VCamFollower : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera _customerCam;
    [SerializeField] private CinemachineVirtualCamera _kitchenCam;

    private void Start()
    {
        GameEventsManager.Instance.OnReturnToKitchen += OnReturnToKitchen;
        GameEventsManager.Instance.OnReturnToCustomer += OnReturnToCustomer;
        GameEventsManager.Instance.OnOrderServed += OnOrderServed;
    }

    private void OnDestroy()
    {
        GameEventsManager.Instance.OnReturnToKitchen -= OnReturnToKitchen;
        GameEventsManager.Instance.OnReturnToCustomer -= OnReturnToCustomer;
        GameEventsManager.Instance.OnOrderServed -= OnOrderServed;
    }

    void OnReturnToKitchen()
    {
        _customerCam.Priority = 9;
        _kitchenCam.Priority = 10;
    }

    private void OnReturnToCustomer()
    {
        _customerCam.Priority = 10;
        _kitchenCam.Priority = 9;
    }

    void OnOrderServed()
    {
        _customerCam.Priority = 10;
        _kitchenCam.Priority = 9;
    }
}
