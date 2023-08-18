using UnityEngine;

public class InstantiatedController : MonoBehaviour
{
    private GameObject _instantiatedObject;
    private SeaweedWrap _seaweedWrap;
    private int _instantiatedIngredientCount;

    public delegate void InstantiatedHandler();
    public event InstantiatedHandler OnInstantiatedObjectCleared;

    public GameObject InstantiatedObject { get => _instantiatedObject; set => _instantiatedObject = value; }
    public SeaweedWrap SeaweedWrap { get => _seaweedWrap; set => _seaweedWrap = value; }
    public int InstantiatedIngredientCount { get => _instantiatedIngredientCount; set => _instantiatedIngredientCount = value; }

    public static InstantiatedController Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        InputManager.Instance.OnRightMouseDown += OnRightMouseDown;
    }

    private void OnDestroy()
    {
        InputManager.Instance.OnRightMouseDown -= OnRightMouseDown;
    }

    private void OnRightMouseDown()
    {
        if(_instantiatedObject != null)
        {
            ClearInstantiatedObject();
        }
    }

    public void ClearInstantiatedObject()
    {
        _instantiatedObject = null;
        OnInstantiatedObjectCleared?.Invoke();
    }
}
