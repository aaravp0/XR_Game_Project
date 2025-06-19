using UnityEngine;

public enum SocketType
{
    StraightWire,
    CurvedWire
}

public class SocketAngleAndType : MonoBehaviour
{
    [Header("Angle Checking")]
    public float assignedAngle;

    [Header("Socket Type")]
    public SocketType expectedType;

    [Tooltip("Layer mask to detect the wire in the socket.")]
    public LayerMask wireLayers;

    public bool IsAtAssignedAngle(float tolerance = 1f)
    {
        float currentX = transform.localEulerAngles.x;
        float delta = Mathf.Abs(Mathf.DeltaAngle(currentX, assignedAngle));
        return delta <= tolerance;
    }

    public bool HasCorrectWireInSocket()
    {
        Collider[] overlaps = Physics.OverlapSphere(transform.position, 0.1f, wireLayers);

        foreach (var hit in overlaps)
        {
            GameObject wire = hit.gameObject;

            // Check the wire's layer and compare it to expected type
            int layer = wire.layer;

            if (expectedType == SocketType.StraightWire && LayerMask.LayerToName(layer).Contains("Straight"))
                return true;

            if (expectedType == SocketType.CurvedWire && LayerMask.LayerToName(layer).Contains("Curved"))
                return true;
        }

        return false;
    }
}
