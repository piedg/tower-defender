using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float speed = 5f;
    int _damage;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    public void SetDamage(int damage)
    {
        _damage = damage;
        Debug.Log("Damage deal " + _damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision != null)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
