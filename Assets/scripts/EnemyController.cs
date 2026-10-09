
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 8f;
    public Rigidbody playerRb;

    private Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (playerRb == null)
            return;

        Vector3 direction = playerRb.position - enemyRb.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.01f)
        {
            enemyRb.AddForce(direction.normalized * speed);
        }
    }
}
