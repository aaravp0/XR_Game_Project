using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketChecker : MonoBehaviour
{
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

                if (objName != null)
                {
                    Transform interactableTransform = objName.transform;

                    int layer2 = interactableTransform.gameObject.layer;

                    if (layer == 9f && layer2 == 9f)
                    {
                        if (xRotation == 270)
                        {
                            xRotation = 90;
                        }
                        if (xRotation == 180)
                        {
                            xRotation = 0;
                        }
                        if (objRotation == 270)
                        {
                            objRotation = 90;
                        }
                        if (objRotation == 180)
                        {
                            objRotation = 0;
                        }
                    }

                    if (xRotation != objRotation || layer != layer2)
                    {
                        allValid = false;
                    }
                }
                else
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
