using UnityEngine;
using UnityEngine.Events;

public class SocketChecker : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent onAllSocketsAligned;
    public UnityEvent onSocketsMisaligned;

    [Header("Options")]
    public float angleTolerance = 1f;
    public bool triggerOnce = true;

    private bool previousAlignmentState = false;

    private void Update()
    {
        bool allCorrect = AreAllSocketsValid(angleTolerance);

        if (allCorrect && (!triggerOnce || !previousAlignmentState))
        {
            onAllSocketsAligned?.Invoke();
        }
        else if (!allCorrect && (!triggerOnce || previousAlignmentState))
        {
            onSocketsMisaligned?.Invoke();
        }

        previousAlignmentState = allCorrect;
    }

    public bool AreAllSocketsValid(float tolerance = 1f)
    {
        foreach (Transform child in transform)
        {
            var socket = child.GetComponent<SocketAngleAndType>();
            if (socket == null)
            {
                Debug.LogWarning($"{child.name} is missing a SocketAngleAndType component.");
                continue;
            }

            if (!socket.IsAtAssignedAngle(tolerance))
            {
                Debug.LogWarning($"{child.name} is misaligned (angle check failed).");
                return false;
            }

            if (!socket.HasCorrectWireInSocket())
            {
                Debug.LogWarning($"{child.name} has incorrect or missing wire.");
                return false;
            }
        }

        return true;
    }
}
