using System.Collections;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    [SerializeField] GameObject KitchenUI;
    [SerializeField] GameObject CustomerUI;

    bool kitchenActive = false;
    bool restaurantActive = true;


    public void Start()
    {
        GameEventsManager.Instance.OnReturnToKitchen += OnReturnToKitchen;
        GameEventsManager.Instance.OnReturnToCustomer += OnReturnToCustomer;
        GameEventsManager.Instance.OnOrderServed += OnOrderServed;

        StartCoroutine(InitialStartCustomerUI());
    }

    public void OnDestroy()
    {
        GameEventsManager.Instance.OnReturnToKitchen -= OnReturnToKitchen;
        GameEventsManager.Instance.OnReturnToCustomer -= OnReturnToCustomer;
        GameEventsManager.Instance.OnOrderServed -= OnOrderServed;
    }

    // Methods
    private void OpenCustomerUI()
    {
        CustomerUI.SetActive(true);
    }

    public void CloseCustomerUI()
    {
        CustomerUI.SetActive(false);
    }

    private void OpenKitchenUI()
    {
        KitchenUI.SetActive(true);
    }

    public void CloseKitchenUI()
    {
        KitchenUI.SetActive(false);
    }

    public void ReturnToCustomer()
    {
        SFXContainer.Instance.PlayMenuClickSFX();

        GameEventsManager.Instance.ReturnCustomer();
    }

    public void ReturnToKitchen()
    {
        SFXContainer.Instance.PlayMenuClickSFX();

        GameEventsManager.Instance.ReturnKitchen();
    }

    public void InstantiateNewOrder()
    {
        SFXContainer.Instance.PlayMenuClickSFX();

        StartCoroutine(CustomerManager.Instance.SetNewOrder());

        StartCoroutine(InitialStartCustomerUI());
    }

    // Event relative methods
    private void OnReturnToCustomer()
    {
        StartCoroutine(ActivateCustomerUI());
    }

    private void OnReturnToKitchen()
    {
        StartCoroutine(ActivateKitchenUI());
    }

    private void OnOrderServed()
    {
        StartCoroutine(ActivateCustomerUI());
    }

    // Coroutines
    IEnumerator ActivateCustomerUI()
    {
        CloseKitchenUI();

        yield return new WaitForSeconds(0.25f);

        OpenCustomerUI();
    }

    IEnumerator ActivateKitchenUI()
    {
        CloseCustomerUI();

        yield return new WaitForSeconds(0.25f);

        OpenKitchenUI();
    }

    // Opens CustomerUI before every order
    IEnumerator InitialStartCustomerUI()
    {
        yield return new WaitForSeconds(Random.Range(2f, 4.5f));

        OpenCustomerUI();
    }
}
