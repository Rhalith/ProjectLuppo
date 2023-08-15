using TMPro;
using UnityEngine;

public class CustomerDialogManager : MonoBehaviour
{
    [SerializeField] TMP_Text dialogText;

    public static CustomerDialogManager Instance;

    private void Start()
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

    public void ChangeText(string text)
    {
        dialogText.text = text;
    }
}
