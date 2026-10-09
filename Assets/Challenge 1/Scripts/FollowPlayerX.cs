
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;

    // Side view camera
    private Vector3 offset = new Vector3(20, 3, 0);

    void LateUpdate()
    {
        if (plane != null)
        {
            transform.position = plane.transform.position + offset;
            transform.LookAt(plane.transform);
        }
    }
}
 