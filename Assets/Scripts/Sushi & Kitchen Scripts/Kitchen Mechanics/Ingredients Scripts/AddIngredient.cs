using UnityEngine;

public class AddIngredient : MonoBehaviour
{
    public GameObject IngredientPrefab;
    public GameObject WrapPrefab;

    [SerializeField] GameObject _nigiriRice;
    [SerializeField] SushiIngredient ingredientName;

    private GameObject instObj;

    private void Start()
    {
        InputManager.Instance.OnLeftMouseDownOver += OnMouseClickOn;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseDownOver -= OnMouseClickOn;
    }

    // Add ingredient
    private void OnMouseClickOn(RaycastHit hit)
    {
        if (hit.collider.CompareTag("SushiMat"))
        {
            if(OrderController.Instance.InstantiatedSushi == null)
            {
                if (WrapPrefab != null)
                {
                    // CuttingBoard
                    instObj = Instantiate(WrapPrefab, transform.position, Quaternion.identity);
                    InstantiatedController.Instance.SeaweedWrap = instObj.GetComponent<SeaweedWrap>();
                    IngredientController.Instance.StartRollingButton.SetActive(true);
                    InstantiatedController.Instance.SeaweedWrap.SushiMatController = hit.collider.GetComponent<SushiMatController>();
                    instObj.transform.SetParent(hit.transform);
                    instObj.transform.localPosition = new Vector3(0.046f, 0.002f, -0.0015f);
                    instObj.transform.localScale = new Vector3(0.87f, 0.87f, 0.87f);
                }
            }
            else
            {
                Debug.Log("We already have a sushi. Destroy or serve it.");
            }
        }
        else if (hit.collider.CompareTag("NigiriPlate"))
        {
            if (WrapPrefab == null)
            {
                // ? Rice þu an ingredient tag'ine sahip. Bu NigiriRice mý?
                if (ingredientName == SushiIngredient.rice)
                {
                    instObj = Instantiate(_nigiriRice, transform.position, Quaternion.identity);
                    instObj.transform.SetParent(hit.transform);
                }
            }
        }
        else if (hit.collider.CompareTag("SeaweedWrap"))
        {
            if (IngredientPrefab != null)
            {
                if (ingredientName == SushiIngredient.rice)
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
