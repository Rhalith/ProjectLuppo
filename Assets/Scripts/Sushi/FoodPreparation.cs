using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPreparation : MonoBehaviour
{
    [Header("Cutting Board")]
    [SerializeField] GameObject cuttingBoard;

    //Not useable anymore
    private void OnMouseDown()
    {
            cuttingBoard.SetActive(true);
            transform.parent.gameObject.SetActive(false);
    }

}
