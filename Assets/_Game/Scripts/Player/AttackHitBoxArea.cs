using UnityEngine;
using System.Collections.Generic;

public class AttackHitBoxArea : MonoBehaviour
{

    Collider hitboxCollider;
    public float damage = 10f;
    private HashSet<EnemyHealth> enemiesHits = new HashSet<EnemyHealth>();

    public void Start()
    {
        hitboxCollider = GetComponent<Collider>();
        hitboxCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == transform.root) 
        {
            return;
        }

        Attack(other);

        Debug.Log("Algo entrou na hitbox: " + other.gameObject.name);
    }

    public void BeginAttack()
    {
        enemiesHits.Clear();
    }

    private void Attack(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

        if (enemyHealth == null)
        {
            return;
        }

        if (enemiesHits.Contains(enemyHealth))
        {
            return;
        }

        enemiesHits.Add(enemyHealth);
        enemyHealth.TakeDamage(damage); 
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    public void EnableObject()
    {
        hitboxCollider.enabled = true;
    }

    public void DisableObject()
    {
        hitboxCollider.enabled = false;
    }
}
