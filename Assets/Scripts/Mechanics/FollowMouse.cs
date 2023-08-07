using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UIElements;

public class FollowMouse : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject ingredientPrefab;
    public GameObject wrapPrefab;
    [SerializeField] GameObject _nigiriRice;
    GameObject hitObject;
    GameObject instObj;
    string ingredientName;
    IngredientController ingredientController;

    //Makes Instantiated objects follow mouse, and when clicked they instantiates objects they symbolize.
    private void Start()
    {
        ingredientController = GameObject.FindWithTag("CustomerManager").GetComponent<IngredientController>();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            
        }
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f))
        {
            transform.position = hit.point;
            hitObject = hit.transform.gameObject;
            
        }

        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                if (hit.collider.CompareTag("ServingSet"))
                {
                    if (wrapPrefab != null)
                    {
                        if (hit.collider.name == "CuttingBoard")
                        {
                            instObj = Instantiate(wrapPrefab, transform.position, Quaternion.identity);
                            wrapPrefab.tag = "Ingredient";
                            instObj.transform.parent = hitObject.transform;
                            instObj.transform.localPosition = new Vector3(0, 0f, 0.00073f);
                            foreach (Transform t in instObj.transform)
                            {
                                t.gameObject.tag = "Ingredient";
                            }
                        }
                    }

                    else if (ingredientPrefab.name == "Rice")
                    {
                        if(hit.collider.name == "NigiriPlate")
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

                if(hit.collider.CompareTag("Ingredient"))
                {
                    if (ingredientPrefab != null)
                    {
                        if (ingredientPrefab.name == "Rice")
                        {
                            if (hit.collider.name == "Plane")
                            {
                                //TODO: Get Child Name for filtering
                                instObj = Instantiate(ingredientPrefab, transform.position, Quaternion.identity);
                                ingredientName = ingredientPrefab.name;
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
                            ingredientName = ingredientPrefab.name;
                            ingredientController.AddIngredient(ingredientName);
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
}

