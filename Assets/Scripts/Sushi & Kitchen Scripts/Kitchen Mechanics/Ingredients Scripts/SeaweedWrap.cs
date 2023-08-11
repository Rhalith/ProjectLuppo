using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaweedWrap : MonoBehaviour
{
    [SerializeField] private RollingAnimation _rollingAnimation;
    [SerializeField] private Transform _maskObject;
    //TODO: all of the sushi prefabs should be in different class
    public GameObject hosomakiPrefab;
    public GameObject chumaki2Prefab;
    public GameObject chumaki3Prefab;
    public GameObject futomakiPrefab;
    private GameObject _instObj;
    //TODO: sushiPos will be assigned in rolling animations end.
    private bool _isRollingEnd;
    Vector3 sushiPos;
    private List<SushiIngredient> _differentSushiIngredients = new ();
    private List<SushiIngredient> _sushiIngredients;

    RaycastHit hit;
    float rollingAmount;
    public List<SushiIngredient> DifferentIngredients { get => _differentSushiIngredients; set => _differentSushiIngredients = new(value); }

    private void Start()
    {
        InputManager.Instance.OnLeftMouseButtonUp += OnLeftMouseButtonUp;
        sushiPos = transform.position;
    }
    private void OnLeftMouseButtonUp()
    {
        if (rollingAmount < 0) rollingAmount = 0;
    }
    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseButtonUp -= OnLeftMouseButtonUp;
    }
    //TODO: knowing issue if player starts from middle, it places maskobject to middle first.
    private void OnMouseDrag()
    {
        if (IngredientController.Instance.IsRolling && !OrderManager.Instance.CinemachineBrain.IsBlending)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                 rollingAmount += InputManager.Instance.MouseInput.x/3;
                if(rollingAmount > 312)
                {
                    rollingAmount = 0;
                    IngredientController.Instance.StopRollingButton.GetComponent<Button>().onClick.Invoke();
                    InstantiateSushi();
                }
                else
                {
                    _rollingAnimation.RollSeaweed(rollingAmount);
                    _maskObject.position = new Vector3(hit.point.x - _maskObject.lossyScale.x / 2, _maskObject.position.y, _maskObject.position.z);
                }

            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 screenMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }

    private void InstantiateSushi()
    {
        //TODO: Must change scriptable object based on their ingredient (mostly done)
        if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(1))
        {
            _sushiIngredients = new (IngredientController.Instance.Ingredients);
            _instObj = Instantiate(hosomakiPrefab, sushiPos, Quaternion.identity);
            //_instObj.GetComponent<HosomakiDisplay>().sushiName = _sushiMaterial + "Hosomaki";
        }
        else if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(2))
        {
            _sushiIngredients = new(IngredientController.Instance.Ingredients);
            _instObj = Instantiate(chumaki2Prefab, sushiPos, Quaternion.identity);
            OrderController.Instance.InstantiatedSushi = _instObj;
            _instObj.GetComponent<ChumakiDisplay>().Ingredients = _sushiIngredients;
            _instObj.GetComponent<ChumakiDisplay>().CheckIngredientList(_differentSushiIngredients);
        }
        else if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(3))
        {
            _sushiIngredients = new(IngredientController.Instance.Ingredients);
            _instObj = Instantiate(chumaki3Prefab, sushiPos, Quaternion.identity);
        }

        else
        {
            _sushiIngredients = new(IngredientController.Instance.Ingredients);
            _instObj = Instantiate(futomakiPrefab, sushiPos, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}