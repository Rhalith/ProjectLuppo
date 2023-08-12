using UnityEngine;

public class AddIngredient : MonoBehaviour
{
    public GameObject IngredientPrefab;
    public GameObject WrapPrefab;

    [SerializeField] GameObject _nigiriRice;
    [SerializeField] SushiIngredient ingredientName;

    RaycastHit hit;
    GameObject instObj;

    private void Start()
    {
        InputManager.Instance.OnLeftMouseDown += OnLeftMouseButtonDown;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseDown -= OnLeftMouseButtonDown;
    }

    // Add ingredient
    private void OnLeftMouseButtonDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            if (hit.collider.CompareTag("ServingSet"))
            {
                if (WrapPrefab != null)
                {
                    if (hit.collider.name == "CuttingBoard")
                    {
                        instObj = Instantiate(WrapPrefab, transform.position, Quaternion.identity);
                        InstantiatedController.Instance.SeaweedWrap = instObj.GetComponent<SeaweedWrap>();
                        IngredientController.Instance.StartRollingButton.SetActive(true);
                        instObj.transform.SetParent(hit.transform);
                        instObj.transform.localPosition = new Vector3(0, -0.009f, 0.0009f);
                        instObj.transform.localRotation = Quaternion.Euler(0, 0, 270);
                    }
                }
                else if (IngredientPrefab.name == "Rice")
                {
                    if (hit.collider.name == "NigiriPlate")
                    {
                        instObj = Instantiate(_nigiriRice, transform.position, Quaternion.identity);
                        instObj.transform.SetParent(hit.transform);
                    }
                }
            }

            if (hit.collider.CompareTag("SeaweedWrap"))
            {
                if (IngredientPrefab != null)
                {
                    if (IngredientPrefab.name == "Rice")
                    {
                        if (hit.collider.name == "Plane")
                        {
                            //TODO: Get Child Name for filtering
                            instObj = Instantiate(IngredientPrefab, transform.position, Quaternion.identity);
                            instObj.transform.SetParent(hit.transform);
                            instObj.transform.localPosition = new Vector3(3, 0, 0);
                        }
                    }
                    else
                    {
                        IngredientController.Instance.AddIngredient(ingredientName);
                        instObj = Instantiate(IngredientPrefab, transform.position, Quaternion.identity);
                        instObj.transform.SetParent(hit.transform);
                    }
                }
            }
        }
    }
}
