using UnityEngine;


public class SocketAngle : MonoBehaviour
{
    public float assignedAngle;

    public bool IsAtAssignedAngle(float tolerance = 1f)
    {
        float currentX = transform.localEulerAngles.x;
        float delta = Mathf.Abs(Mathf.DeltaAngle(currentX, assignedAngle));
        return delta <= tolerance;
    }

}