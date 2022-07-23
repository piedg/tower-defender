using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Cost;
    public int Hits;

    public void TakeDamage(int hit)
    {
        Hits -= hit;

        if(Hits <= 0)
        {
            Destroy(gameObject);
        }
    }
}
