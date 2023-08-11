using UnityEngine;

public class ObjectCreator : MonoBehaviour 
{
    [SerializeField] GameObject objectPref;

    private GameObject _instantiatedObject;

    private void Start()
    {
        InstantiatedController.Instance.OnInstantiatedObjectCleared += OnInstantiatedObjectCleared;
    }

    private void OnDestroy()
    {
        InstantiatedController.Instance.OnInstantiatedObjectCleared -= OnInstantiatedObjectCleared;
    }

    private void OnMouseDown()
    {
        if (!InstantiatedController.Instance.InstantiatedObject)
        {
            InstantiateIngredientObject();
        }
        else
        {
            if (InstantiatedController.Instance.InstantiatedObject.Equals(_instantiatedObject))
            {
                DestroySushiObjectIfExists();
            }
            else
            {
                DestroySushiObjectIfExists();
                InstantiateIngredientObject();
            }
        }
    }

    public void InstantiateIngredientObject()
    {
        _instantiatedObject = Instantiate(objectPref);
        InstantiatedController.Instance.InstantiatedObject = _instantiatedObject;
    }

    public void DestroySushiObjectIfExists()
    {
        InstantiatedController.Instance.ClearInstantiatedObject();
    }

    private void OnInstantiatedObjectCleared()
    {
        Destroy(_instantiatedObject);
    }
}
