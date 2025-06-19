using UnityEngine;

public class RotateOnSocket : MonoBehaviour
{

    // This function will be called to rotate the object
    public void RotateX()
    {
        transform.Rotate(90f, 0f, 0f);
    }
}