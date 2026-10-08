using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{

    [SerializeField] AttackHitBoxArea attackHitBoxArea;
    private PlayerInputActions inputActions;
    public float attackDuration = 0.2f;
    public float attackDamage = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        inputActions = new PlayerInputActions();
        inputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        CheckAttack();
    }

    private void CheckAttack()
    {
        if (inputActions.Player.Attack.WasPressedThisFrame())
        {
            StartCoroutine(AttackDuration());
        }
    }

    private IEnumerator AttackDuration()
    {
        attackHitBoxArea.EnableObject();
        attackHitBoxArea.setDamage(attackDamage);
        yield return new WaitForSeconds(attackDuration);
        attackHitBoxArea.DisableObject();
    }
}
