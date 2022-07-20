using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : Character
{
    [SerializeField] int producedPower;

    private void Update()
    {
        ProducePower();
    }

    void ProducePower()
    {
        GameManager.Instance.AddPowerOverTime(producedPower);
    }
}
