using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int Hits;

    void Update()
    {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }

    public void TakeDamage(int hit)
    {
        Hits -= hit;

        if (Hits <= 0)
        {
            Destroy(gameObject);
        }
    }
}
