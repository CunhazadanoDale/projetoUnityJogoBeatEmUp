using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private EnemyDamageFlash damageFlash;
    [SerializeField] private EnemyKnockback knockback;
    public float health = 100f;
    private bool isDead = false;

    public void Awake()
    {
        if (knockback == null)
        {
            knockback = GetComponent<EnemyKnockback>();
        }
    }
    
    public void TakeDamage(float damage, Vector3 attackerPosition)
    {
        if (isDead)
        {
            return;
        }

        if (damageFlash != null)
        {
            damageFlash.Flash();
        }

        if (knockback != null)
        {
            knockback.ApplyKnockback(attackerPosition);
        }

        health -= damage;
        Debug.Log("Inimigo recebeu dano. Vida atual: " + health);
        if (health <= 0f)
        {
            isDead = true;
            Debug.Log("Enemy died");
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
