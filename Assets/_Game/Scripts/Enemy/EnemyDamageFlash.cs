
using UnityEngine;
using System.Collections;

public class EnemyDamageFlash : MonoBehaviour
{
    [SerializeField] private Renderer enemyRenderer;
    [SerializeField] private Color damageColor = Color.red;
    [SerializeField] private float flashDuration = 0.15f;

    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        if (enemyRenderer == null)
        {
            enemyRenderer = GetComponentInChildren<Renderer>();
        }

        if (enemyRenderer != null)
        {
            originalColor = enemyRenderer.material.color;
        }
    }

    public void Flash()
    {
        if (enemyRenderer == null)
        {
            return;
        }

        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        enemyRenderer.material.color = damageColor;

        yield return new WaitForSeconds(flashDuration);

        enemyRenderer.material.color = originalColor;

        flashCoroutine = null;
    }
}
