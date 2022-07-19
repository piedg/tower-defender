using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> initialCards = new List<GameObject>();

    private void Awake()
    {
        foreach (GameObject card in initialCards)
        {
            GameObject cardInstance = Instantiate(card);
            cardInstance.transform.SetParent(UIManager.Instance.cardContainer.transform, false);
        }
    }
}
