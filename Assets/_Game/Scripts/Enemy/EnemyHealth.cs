using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 100f;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Inimigo recebeu dano. Vida atual: " + health);
        if (health <= 0f)
        {
            Debug.Log("Enemy died");
            gameObject.SetActive(false);
        }
    }
}
