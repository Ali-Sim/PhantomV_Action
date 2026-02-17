using UnityEngine;

public class RotatingPickups : MonoBehaviour
{
    float moveDistance = 0.25f; // how far the object moves up/down
    float moveSpeed = 2.0f;   // speed of the object moving

    Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position; // original position
    }

    void FixedUpdate()
    {
        //transform.Rotate(new Vector3(0f, 3f, 0f)); //constantly spin on the y axis // NOT NEEDED SO WAS REMOVED

        // Calculate the new Y position using a sine wave so it moves up and down
        float newY = originalPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;

        // new object position
        transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);
    }
}
