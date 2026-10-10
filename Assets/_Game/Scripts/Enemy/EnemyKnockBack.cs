
using UnityEngine;
using System.Collections;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackDistance = 1.5f;
    [SerializeField] private float knockbackDuration = 0.15f;

    private bool isBeingKnockedBack = false;

    public void ApplyKnockback(Vector3 attackerPosition)
    {
        if (isBeingKnockedBack)
        {
            return;
        }

        Vector3 direction = transform.position - attackerPosition;
        direction.y = 0f;

        if (direction.sqrMagnitude == 0f)
        {
            return;
        }

        direction.Normalize();

        StartCoroutine(KnockbackRoutine(direction));
    }

    private IEnumerator KnockbackRoutine(Vector3 direction)
    {
        isBeingKnockedBack = true;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition + direction * knockbackDistance;

        float elapsedTime = 0f;

        while (elapsedTime < knockbackDuration)
        {
            transform.position = Vector3.Lerp(
                startPosition,
                targetPosition,
                elapsedTime / knockbackDuration
            );

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPosition;

        isBeingKnockedBack = false;
    }
}
