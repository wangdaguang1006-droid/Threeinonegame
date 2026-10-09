
using UnityEngine;

public class PlayerControllerBall : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(
            horizontalInput,
            0,
            verticalInput
        );

        rb.AddForce(movement * speed);
    }
}
