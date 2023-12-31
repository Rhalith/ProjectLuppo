using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeaweedWrap : MonoBehaviour
{
    [SerializeField] private RollingAnimation _rollingAnimation;
    [SerializeField] private SushiMatController _sushiMatController;
    [SerializeField] private Transform _maskObject;
    //TODO: all of the sushi prefabs should be in different class
    public GameObject salmonHosomakiPrefab;
    public GameObject cucumberHosomakiPrefab;
    public GameObject salmonCucumberChumakiPrefab;
    private GameObject _instObj;
    //TODO: sushiPos will be assigned in rolling animations end.
    private bool _isRollingEnd;
    Vector3 sushiPos;
    private List<SushiIngredient> _differentSushiIngredients = new ();
    private List<SushiIngredient> _sushiIngredients;

    RaycastHit hit;
    float rollingAmount;
    public List<SushiIngredient> DifferentIngredients { get => _differentSushiIngredients; set => _differentSushiIngredients = new(value); }
    public SushiMatController SushiMatController { get => _sushiMatController; set => _sushiMatController = value; }

    private void Start()
    {
        InputManager.Instance.OnLeftMouseUp += OnLeftMouseButtonUp;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnLeftMouseUp -= OnLeftMouseButtonUp;
    }

    private void OnLeftMouseButtonUp()
    {
        if (rollingAmount < 0) 
            rollingAmount = 0;
    }

    //TODO: knowing issue if player starts from middle, it places maskobject to middle first.
    private void OnMouseDrag()
    {
        if (IngredientController.Instance.IsRolling && !OrderManager.Instance.CinemachineBrain.IsBlending)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 50000.0f))
            {
                rollingAmount += InputManager.Instance.MouseInput.y/3;
                if(rollingAmount > 12)
                {
                    rollingAmount = 0;
                    _sushiMatController.StartRolling();
                    _rollingAnimation.StartRolling();
                }
            }
        }
    }

    public void CheckIngredientList()
    {
        _sushiIngredients = new(IngredientController.Instance.Ingredients);

        if(_differentSushiIngredients.Count == 1)
        {
            if (_sushiIngredients.Contains(SushiIngredient.cucumber))
            {
                OrderController.Instance.SushiType = OrderedSushiType.CucumberHosomaki;
            }
            else if (_sushiIngredients.Contains(SushiIngredient.salmon))
            {
                OrderController.Instance.SushiType = OrderedSushiType.SalmonHosomaki;
            }
        }
        else if (_differentSushiIngredients.Count == 2)
        {
            if (_sushiIngredients.Contains(SushiIngredient.cucumber))
            {
                if (_sushiIngredients.Contains(SushiIngredient.salmon))
                {
                    OrderController.Instance.SushiType = OrderedSushiType.SalmonCucumberChumaki;
                }
            }
        }

        OrderController.Instance.Ingredients = _sushiIngredients;
        IngredientController.Instance.ClearIngredient();
    }

    public void InstantiateSushi()
    {
        IngredientController.Instance.StopRollingButton.GetComponent<Button>().onClick?.Invoke();
        IngredientController.Instance.StartRollingButton.SetActive(false);

        sushiPos = transform.position;
        sushiPos.x += 2.4f; sushiPos.y += 0.3f; sushiPos.z -= 0.1f;
        //TODO: Must change scriptable object based on their ingredient (mostly done)
        if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(1))
        {
            CheckIngredientList();

            //TODO: This will be changed after adding more orders
            if (OrderController.Instance.SushiType.Equals(OrderedSushiType.SalmonHosomaki))
            {
                _instObj = Instantiate(salmonHosomakiPrefab);
            }
            else if (OrderController.Instance.SushiType.Equals(OrderedSushiType.CucumberHosomaki))
            {
                _instObj = Instantiate(cucumberHosomakiPrefab);
            }

            _instObj.transform.position = sushiPos;
            OrderController.Instance.InstantiatedSushi = _instObj;

            _instObj.GetComponent<HosomakiDisplay>().Ingredients = _sushiIngredients;
            _instObj.GetComponent<HosomakiDisplay>().CheckIngredientList(OrderController.Instance.SushiType);
        }
        else if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(2))
        {
            CheckIngredientList();

            if (OrderController.Instance.SushiType.Equals(OrderedSushiType.SalmonCucumberChumaki))
            {
                _instObj = Instantiate(salmonCucumberChumakiPrefab);
            }

            _instObj.transform.position = sushiPos;
            OrderController.Instance.InstantiatedSushi = _instObj;

            _instObj.GetComponent<ChumakiDisplay>().Ingredients = _sushiIngredients;
            _instObj.GetComponent<ChumakiDisplay>().CheckIngredientList(_differentSushiIngredients);
        }
        /*
        else if (InstantiatedController.Instance.InstantiatedIngredientCount.Equals(3))
        {
            _sushiIngredients = new(IngredientController.Instance.Ingredients);
            _instObj = Instantiate(chumaki3Prefab);
            _instObj.transform.position = sushiPos;
            OrderController.Instance.InstantiatedSushi = _instObj;
        }
        else
        {
            _sushiIngredients = new(IngredientController.Instance.Ingredients);
            _instObj = Instantiate(futomakiPrefab);
            _instObj.transform.position = sushiPos;
        }
        */

        Destroy(gameObject);
    }
}