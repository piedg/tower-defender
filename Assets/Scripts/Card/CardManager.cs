using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoSingleton<CardManager>
{
    Vector3 mousePos;
    public GameObject tempInstance { get; set; }
    bool hasCard;

    int cardCost;

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (tempInstance != null)
        {
            hasCard = true;
            tempInstance.transform.position = new Vector3(mousePos.x, mousePos.y, 0f);

            if (Input.GetMouseButton(1))
            {
                Destroy(tempInstance);
            }
        }
        else
            hasCard = false;
    }

    public void OnCardClick(GameObject character)
    {
        if (hasCard) return;

        Debug.Log("Card clicked " + character.name);
        cardCost = character.GetComponent<Character>().cost;

        GameObject _instance = Instantiate(character, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            _instance.transform.position = mousePos;

        _instance.GetComponentInChildren<SpriteRenderer>().sortingOrder = 100;
        tempInstance = _instance;
    }

    public GameObject SpawnCharacter(GameObject character, Vector3 spawnPosition)
    {
        if(GameManager.Instance.CurrentPower >= cardCost)
        {
            if (tempInstance != null)
            {
                GameObject charInstance = Instantiate(tempInstance, spawnPosition, Quaternion.identity);
                charInstance.GetComponentInChildren<SpriteRenderer>().sortingOrder = 10;

                GameManager.Instance.Withdraw(cardCost);

                Destroy(tempInstance);
                return character = charInstance;
            }
        }
        return null;
    }

    public void DestroyInstance(GameObject instance)
    {
        instance = null;
    }
}
