using UnityEngine;

public class SFXContainer : MonoBehaviour
{
    [Header("SFX's")]
    [SerializeField] private AudioClip customerStepSFX;
    [SerializeField] private AudioClip dialogSFX;
    [SerializeField] private AudioClip checkoutSFX;
    [SerializeField] private AudioClip sliceSFX;
    [SerializeField] private AudioClip ingredientPlaceChangeSFX;
    [SerializeField] private AudioClip menuClickSFX;
    [SerializeField] private AudioClip sushiRollingSFX;
    [SerializeField] private AudioClip vegetableSlicingSFX;
    [SerializeField] private AudioClip gettingOrderSFX;
    [SerializeField] private AudioClip plateSFX;
    [SerializeField] private AudioClip trashCanSFX;

    public static SFXContainer Instance { get; private set; }

    private void Start()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void PlayCustomerStep()
    {
        AudioManager.instance.PlaySound(customerStepSFX);
    }

    public void PlayDialogSFX()
    {
        AudioManager.instance.PlaySound(dialogSFX);
    }

    public void PlayCheckoutSFX()
    {
        AudioManager.instance.PlaySound(checkoutSFX);
    }

    public void PlayCSliceSFX()
    {
        AudioManager.instance.PlaySound(sliceSFX);
    }

    public void PlayIngredientPlaceChangeSFX()
    {
        AudioManager.instance.PlaySound(ingredientPlaceChangeSFX);
    }

    public void PlayMenuClickSFX()
    {
        AudioManager.instance.PlaySound(menuClickSFX);
    }

    public void PlaySushiRollingSFX()
    {
        AudioManager.instance.PlaySound(sushiRollingSFX);
    }

    public void PlayVegetableSlicingSFX()
    {
        AudioManager.instance.PlaySound(vegetableSlicingSFX);
    }

    public void PlayGettingOrderSFX()
    {
        AudioManager.instance.PlaySound(gettingOrderSFX);
    }

    public void PlayPlateSFX()
    {
        AudioManager.instance.PlaySound(plateSFX);
    }

    public void PlayTrashCanSFX()
    {
        AudioManager.instance.PlaySound(trashCanSFX);
    }
}
