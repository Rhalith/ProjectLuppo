using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCamFollower : MonoBehaviour
{

    CinemachineVirtualCamera vcam;

    [SerializeField] GameObject KitchenCam;
    [SerializeField] GameObject RestaurantCam;
    private void Start()
    {
        GameEventsManager.Instance.OnKitchenActivated += OnKitchenActivated;
        GameEventsManager.Instance.OnRestaurantActivated += OnRestaurantActivated;
        GameEventsManager.Instance.OnServingAdded += OnServingAdded;

        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void OnKitchenActivated()
    {
        vcam.LookAt = KitchenCam.transform;
    }

    private void OnRestaurantActivated()
    {
        vcam.LookAt = RestaurantCam.transform;
    }

    void OnServingAdded()
    {
        vcam.LookAt = RestaurantCam.transform;
    }
}
