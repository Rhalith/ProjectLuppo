using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject ingredientPrefab;
    public GameObject wrapPrefab;

    [SerializeField] GameObject _nigiriRice;
    [SerializeField] SushiIngredient ingredientName;

    RaycastHit hit;
    GameObject hitObject;
    GameObject instObj;

    private void Start()
    {
        InputManager.Instance.OnLeftMouseButtonDown += OnLeftMouseButtonDown;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseButtonDown -= OnLeftMouseButtonDown;
    }

    private void Update()
    {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         if (Physics.Raycast(ray, out hit, 50000.0f))
         {
             transform.position = hit.point;
             hitObject = hit.transform.gameObject;
         }
    }

    private void OnLeftMouseButtonDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            hitObject = hit.transform.gameObject;
        }

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            if (hit.collider.CompareTag("ServingSet"))
            {
                if (wrapPrefab != null)
                {
                    if (hit.collider.name == "CuttingBoard")
                    {
                        instObj = Instantiate(wrapPrefab, transform.position, Quaternion.identity);
                        InstantiatedController.Instance.SeaweedWrap = instObj.GetComponent<SeaweedWrap>();
                        instObj.transform.parent = hitObject.transform;
                        instObj.transform.localPosition = new Vector3(0, 0f, 0.00073f);
                    }
                }
                else if (ingredientPrefab.name == "Rice")
                {
                    if (hit.collider.name == "NigiriPlate")
                    {
                        instObj = Instantiate(_nigiriRice, transform.position, Quaternion.identity);
                        ingredientPrefab.tag = "Ingredient";
                        instObj.transform.parent = hitObject.transform;
                        foreach (Transform t in instObj.transform)
                        {
                            t.gameObject.tag = "Ingredient";
                        }
                    }
                }
            }

            if (hit.collider.CompareTag("Ingredient"))
            {
                if (ingredientPrefab != null)
                {
                    if (ingredientPrefab.name == "Rice")
                    {
                        if (hit.collider.name == "Plane")
                        {
                            //TODO: Get Child Name for filtering
                            instObj = Instantiate(ingredientPrefab, transform.position, Quaternion.identity);
                            ingredientPrefab.tag = "Ingredient";
                            instObj.transform.parent = hitObject.transform;
                            foreach (Transform t in instObj.transform)
                            {
                                t.gameObject.tag = "Ingredient";
                            }
                            instObj.transform.localPosition = new Vector3(3, 0, 0);
                        }
                    }
                    else
                    {
                        IngredientController.Instance.AddIngredient(ingredientName);
                        instObj = Instantiate(ingredientPrefab, transform.position, Quaternion.identity);
                        ingredientPrefab.tag = "Ingredient";
                        instObj.transform.parent = hitObject.transform;
                        foreach (Transform t in instObj.transform)
                        {
                            t.gameObject.tag = "Ingredient";
                        }
                    }
                }
            }
        }
    }
}

