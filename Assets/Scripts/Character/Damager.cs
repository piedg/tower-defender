using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : Character
{
    [SerializeField] int damage;
    [SerializeField] float firingDistance;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right,firingDistance, LayerMask.GetMask("Enemy"));

        if(hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    void Shoot()
    {
        Debug.Log("Dealing " + damage + " damage");
    }
}
