using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : Character
{
    [SerializeField] int damage;

    private void Start()
    {
        Debug.Log("Damage " + damage);
    }
}
