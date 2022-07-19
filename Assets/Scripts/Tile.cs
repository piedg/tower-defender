using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Color baseColor, offsetColor;
    [SerializeField] SpriteRenderer sprite;

    GameObject actualCharacter;
    bool isFilled;

    CardManager cardManager;

    private void Awake()
    {
        cardManager = FindObjectOfType<CardManager>();
    }

    private void Update()
    {
        if(actualCharacter != null)
        {
            isFilled = true;
        }
    }

    public void Init(bool isOffSet)
    {
        sprite.color = isOffSet ? offsetColor : baseColor;
    }
   
    private void OnMouseDown()
    {
       if (isFilled) return;

       if(cardManager.tempInstance != null)
        {
            GameObject charInstance = Instantiate(cardManager.tempInstance, transform.position, Quaternion.identity);
            Destroy(cardManager.tempInstance);

            charInstance.GetComponentInChildren<SpriteRenderer>().sortingOrder = 10;

            actualCharacter = charInstance;
        }
    }
}
