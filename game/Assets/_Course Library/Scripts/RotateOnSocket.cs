using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateOnSocket : MonoBehaviour
{
    public void RotateX()
    {
        transform.Rotate(90f, 0f, 0f);
    }
}
