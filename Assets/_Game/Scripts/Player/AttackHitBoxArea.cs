using UnityEngine;

public class AttackHitBoxArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root == transform.root) 
        {
            return;
        }

        Debug.Log("Algo entrou na hitbox: " + other.gameObject.name);
    }

    public void EnableObject()
    {
        gameObject.SetActive(true);
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
