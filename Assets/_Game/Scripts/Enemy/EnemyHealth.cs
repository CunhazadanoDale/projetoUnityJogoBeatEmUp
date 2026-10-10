using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{

    public float health = 100f;
    private bool isDead = false;
    
    public void TakeDamage(float damage)
    {
        if (isDead)
        {
            return;
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
