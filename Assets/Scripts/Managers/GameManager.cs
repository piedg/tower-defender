using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public List<GameObject> initialCards = new List<GameObject>();

    [SerializeField] int startingPower = 150;
    [SerializeField] int currentPower;

    float timer;
    [SerializeField] int delayAmount;

    public int CurrentPower { get { return currentPower; } }

    private void Start()
    {
        foreach (GameObject card in initialCards)
        {
            GameObject cardInstance = Instantiate(card);
            cardInstance.transform.SetParent(UIManager.Instance.cardContainer.transform, false);
        }

        currentPower = startingPower;
        UIManager.Instance.UpdatePowerBalance(currentPower);
    }

    private void Update()
    {
        AddPowerOverTime(50);
    }

    public void Deposit(int amount)
    {
        currentPower += Mathf.Abs(amount);

        UIManager.Instance.UpdatePowerBalance(currentPower);
    }

    public void Withdraw(int amount)
    {
        if(currentPower >= amount)
        {
            currentPower -= Mathf.Abs(amount);
        }

        UIManager.Instance.UpdatePowerBalance(currentPower);
    }

    public void AddPowerOverTime(int amount)
    {
        timer += Time.deltaTime;

        if (timer >= delayAmount)
        {
            timer = 0f;
            currentPower += amount; 
            UIManager.Instance.UpdatePowerBalance(currentPower);
        }
    }

}
