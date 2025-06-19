using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecker : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent onAllSocketsAligned;
    public UnityEvent onSocketsMisaligned;

    public void AreAllSocketsValid()
    {
        bool allValid = true;

        foreach (Transform child in transform)
        {
            if (allValid)
            {
                Transform secondChild = child.GetChild(0);

                float xRotation = secondChild.eulerAngles.x;

                // Normalize the rotation to be between 0 and 360
                if (xRotation < 0)
                {
                    xRotation += 360f;
                }
                else if (xRotation > 360f)
                {
                    xRotation -= 360f;
                }

                SocketAngleAndType obj = child.GetComponent<SocketAngleAndType>();

                float objRotation = obj.assignedAngle;

                int layer = child.gameObject.layer;

                XRSocketInteractor socket = child.GetComponent<XRSocketInteractor>();

                IXRSelectInteractable objName = socket.GetOldestInteractableSelected();

                Transform interactableTransform = objName.transform;

                int layer2 = interactableTransform.gameObject.layer;

                if(layer )

                if (xRotation != objRotation || layer != layer2)
                {
                    allValid = false;
                }
            }
        }

        if(allValid)
        {
            onAllSocketsAligned?.Invoke();
        }
        else
        {
            onSocketsMisaligned?.Invoke();
        }

    }
}
