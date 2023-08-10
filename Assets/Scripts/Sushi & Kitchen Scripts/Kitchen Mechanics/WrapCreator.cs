using UnityEngine;

public class WrapCreator : MonoBehaviour
{
    [SerializeField] GameObject _createPrefab;
    private GameObject _instantiatedObject;

    private void OnMouseDown()
    {
        if (!InstantiatedController.Instance.InstantiatedObject)
        {
            InstantiateIngredientObject();
        }
        else if (!InstantiatedController.Instance.InstantiatedObject.Equals(_instantiatedObject))
        {
            DestroySushiObjectIfExists();
            InstantiateIngredientObject();
        }
        else
        {
            DestroySushiObjectIfExists();
        }
    }
        
    public void InstantiateIngredientObject()
    {
        _instantiatedObject = Instantiate(_createPrefab);
        InstantiatedController.Instance.InstantiatedObject = _instantiatedObject;
    }

    public void DestroySushiObjectIfExists()
    {
        InstantiatedController.Instance.ClearInstantiatedObject();
        Destroy(_instantiatedObject);
    }
}
