using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateOnSocket : MonoBehaviour
{
    public XRSocketInteractor socket;

    public void RotateX()
    {
        transform.Rotate(90f, 0f, 0f);
    }
}
