using UnityEngine;

public class UpAndDownMovement : MonoBehaviour
{
    public float speed = 2.0f; // Speed of the movement
    public float height = 2.0f; // Distance to move up and down

    private Vector3 startPos;
    private Vector3 endPos;
    private float lerpTime;

    void Start()
    {
        // Store the starting position of the GameObject
        startPos = transform.position;
        // Calculate the end position by adding the height to the start position
        endPos = new Vector3(startPos.x, startPos.y + height, startPos.z);
    }

    void Update()
    {
        // Calculate the time factor based on speed
        lerpTime += Time.deltaTime * speed;

        // Interpolate between startPos and endPos using Mathf.PingPong to create the up and down motion
        float t = Mathf.PingPong(lerpTime, 1.0f);

        // Set the new position
        transform.position = Vector3.Lerp(startPos, endPos, t);
    }
}
