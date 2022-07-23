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
        AddPowerOverTime(25, delayAmount);
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

    public void AddPowerOverTime(int _amount, float _delayAmount)
    {
        this.timer += Time.deltaTime;

        if (this.timer >= _delayAmount)
        {
            this.timer = 0f;
            this.currentPower += _amount; 
            UIManager.Instance.UpdatePowerBalance(currentPower);
        }
    }

}
