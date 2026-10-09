
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    public float turnSpeed = 60f;

    private float horizontalInput;
    private float verticalInput;

    private Collider carCollider;

    void Start()
    {
        carCollider = GetComponent<Collider>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        float turn = horizontalInput * turnSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, turn, 0);

        float distance = verticalInput * speed * Time.fixedDeltaTime;

        if (carCollider == null || Mathf.Approximately(distance, 0f))
            return;

        Vector3 direction = distance > 0
            ? transform.forward
            : -transform.forward;

        Vector3 halfExtents = carCollider.bounds.extents * 0.9f;

        bool blocked = Physics.BoxCast(
            carCollider.bounds.center,
            halfExtents,
            direction,
            out RaycastHit hit,
            transform.rotation,
            Mathf.Abs(distance) + 0.05f,
            ~0,
            QueryTriggerInteraction.Ignore
        ) && hit.collider.gameObject != gameObject
          && !hit.collider.transform.IsChildOf(transform);

        if (!blocked)
        {
            transform.position += direction * Mathf.Abs(distance);
        }
    }
}
