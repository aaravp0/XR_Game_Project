using UnityEngine;
<<<<<<< HEAD

public class RotateOnSocket : MonoBehaviour
{

    // This function will be called to rotate the object
    public void RotateX()
    {
        transform.Rotate(90f, 0f, 0f);
    }
}
=======
using UnityEngine.XR.Interaction.Toolkit;

public class RotateOnSocket : MonoBehaviour
{
    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
        socket.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDestroy()
    {
        socket.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        Transform objTransform = args.interactableObject.transform;
        objTransform.Rotate(90f, 0f, 0f); // Rotates 90 degrees around X-axis
    }
}
>>>>>>> parent of d19dad5 (Finished Rotating Wires)
