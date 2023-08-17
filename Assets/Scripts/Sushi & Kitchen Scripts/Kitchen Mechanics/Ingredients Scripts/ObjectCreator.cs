using UnityEngine;

public class ObjectCreator : MonoBehaviour 
{
    [SerializeField] GameObject objectPref;

    private GameObject _instantiatedObject;

    private void Start()
    {
        InstantiatedController.Instance.OnInstantiatedObjectCleared += OnInstantiatedObjectCleared;
        InputManager.Instance.OnLeftMouseDownOver += OnLeftMouseDownOver;
    }

    private void OnDestroy()
    {
        InstantiatedController.Instance.OnInstantiatedObjectCleared -= OnInstantiatedObjectCleared;
        InputManager.Instance.OnLeftMouseDownOver -= OnLeftMouseDownOver;
    }

    private void OnLeftMouseDownOver(RaycastHit hit)
    {
        // Þu an box'larýn tag'leri olmadýðý için isimle kontrol ediyoruz.
        if(hit.collider.gameObject.name.Equals(gameObject.name) && !IngredientController.Instance.IsRolling)
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
