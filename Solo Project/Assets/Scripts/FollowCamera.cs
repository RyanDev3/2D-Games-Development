using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public Camera cam;
    public float horizontalMargin = 0.3f;
    public float verticalMargin = 0.4f;

    public float depth = -10;

    Vector3 target;
    Vector3 lastPosition;

    public float smoothTime = 0.25f;
    Vector3 currentVelocity;

    private void LateUpdate()
    {
        SetTarget();
        MoveCamera();
    }

    void SetTarget()
    {
        Vector3 movementDelta = player.position - lastPosition;
        Vector3 screenPos = cam.WorldToScreenPoint(player.position);
        Vector3 bottomLeft = cam.ViewportToScreenPoint(new Vector3(horizontalMargin, verticalMargin, 0));
        Vector3 topRight = cam.ViewportToScreenPoint(new Vector3(1 - horizontalMargin, 1 - verticalMargin, 0));

      

        if (screenPos.y < bottomLeft.y || screenPos.y > topRight.y)
        {
            target.y += movementDelta.y;
        }

        target.z = depth;
        lastPosition = player.position;
    }

    void MoveCamera()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target, ref currentVelocity, smoothTime);
    }
}