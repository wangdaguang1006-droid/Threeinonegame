
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;

    private float verticalInput;

    void FixedUpdate()
    {
        // Get input from up and down arrow keys
        verticalInput = Input.GetAxis("Vertical");

        // Move the plane forward
        transform.Translate(
            Vector3.forward * speed * Time.deltaTime
        );

        // Rotate the plane up and down
        transform.Rotate(
            Vector3.right * rotationSpeed * verticalInput * Time.deltaTime
        );
    }
}
