using UnityEngine;

public class AttackHitBoxArea : MonoBehaviour
{

    Collider hitboxCollider;
    public float damage = 10f;

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

        AttackDamage(other);

        Debug.Log("Algo entrou na hitbox: " + other.gameObject.name);
    }

    private void AttackDamage(Collider other)
    {
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    public void setDamage(float damage)
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
