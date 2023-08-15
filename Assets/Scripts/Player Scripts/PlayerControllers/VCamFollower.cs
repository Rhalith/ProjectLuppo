using Cinemachine;
using UnityEngine;

public class VCamFollower : MonoBehaviour
{
    [SerializeField] private GameObject kitchenCam;
    [SerializeField] private GameObject restaurantCam;

    private CinemachineVirtualCamera _vcam;

    private void Start()
    {
        GameEventsManager.Instance.OnKitchenActivated += OnKitchenActivated;
        GameEventsManager.Instance.OnRestaurantActivated += OnRestaurantActivated;
        GameEventsManager.Instance.OnOrderServed += OnOrderServed;

        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    private void OnDestroy()
    {
        GameEventsManager.Instance.OnKitchenActivated -= OnKitchenActivated;
        GameEventsManager.Instance.OnRestaurantActivated -= OnRestaurantActivated;
        GameEventsManager.Instance.OnOrderServed -= OnOrderServed;
    }

    void OnKitchenActivated()
    {
        _vcam.LookAt = kitchenCam.transform;
    }

    private void OnRestaurantActivated()
    {
        _vcam.LookAt = restaurantCam.transform;
    }

    void OnOrderServed()
    {
        _vcam.LookAt = restaurantCam.transform;
    }
}
