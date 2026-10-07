using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private PlayerInputActions playerInputActions;
    private CharacterController characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    // Update is called once per frame
    void Update()
    {
       MovePlayer();
    }


    private void MovePlayer()
    {
        moveInput = playerInputActions.Player.Move.ReadValue<Vector2>();
       Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
}
