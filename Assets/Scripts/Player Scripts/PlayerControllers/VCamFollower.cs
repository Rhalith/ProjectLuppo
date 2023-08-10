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
        GameEventsManager.Instance.OnServingAdded += OnServingAdded;

        _vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void OnKitchenActivated()
    {
        _vcam.LookAt = kitchenCam.transform;
    }

    private void OnRestaurantActivated()
    {
        _vcam.LookAt = restaurantCam.transform;
    }

    void OnServingAdded()
    {
        _vcam.LookAt = restaurantCam.transform;
    }
}
