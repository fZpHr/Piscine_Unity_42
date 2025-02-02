using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody _rigidBody;
    private bool isGrounded;
    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (transform.position.y <= 1) {
            _rigidBody.linearVelocity = Vector3.zero;
            transform.position = new Vector3(-14.48938f, 14.34766f, 45.66f);
            Debug.Log("You died");
        }

        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = -Input.GetAxis("Vertical");
        playerInput.Normalize();
        var movementVector = new Vector3(playerInput.y , 0f, playerInput.x);
        _rigidBody.AddForce(movementVector*speed);

        if (Input.GetKey(KeyCode.Space) && isGrounded){
            _rigidBody.AddForce(Vector3.up * 1f, ForceMode.Impulse);
        }
    }
}