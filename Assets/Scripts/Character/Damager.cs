using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : Character
{
    int _damage;

    [SerializeField] float aimDistance;
    [SerializeField] float firingRate;
    float nextFire;

    [SerializeField] GameObject projectilePrefab;
    private void Start()
    {
        _damage = base.cardSO.damage;
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, aimDistance, LayerMask.GetMask("Enemy"));

        if (hit.collider != null)
        {
            Shoot();
            Debug.Log(hit.collider.gameObject.name);
        }
    }

    void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + firingRate;
            GameObject _instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            _instance.GetComponent<Projectile>().SetDamage(_damage);
        }
    }

}
