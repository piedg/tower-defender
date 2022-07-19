using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{
    public CardManager cardManager;

    public CardSO cardSO;

    public Image cardArtwork;
    public TextMeshProUGUI costText;
    public GameObject characterPrefab;

    private void Start()
    {
        cardArtwork.sprite = cardSO.artwork;
        costText.text = cardSO.cost.ToString();

        this.GetComponent<Button>().onClick.AddListener(() => cardManager.OnCardClick(GetCharacter()));
    }
    
    public GameObject GetCharacter()
    {
        return characterPrefab;
    }
}
