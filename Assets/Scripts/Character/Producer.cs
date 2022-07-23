using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : Character
{
    [SerializeField] int producedPower;
    float delayAmount;

    private void Update()
    {
        ProducePower();
    }

    void ProducePower()
    {
        GameManager.Instance.AddPowerOverTime(producedPower, Random.Range(5f, 20f));
    }
}
