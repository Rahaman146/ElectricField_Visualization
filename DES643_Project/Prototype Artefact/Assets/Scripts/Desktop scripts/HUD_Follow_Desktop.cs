using UnityEngine;

public class HUD_Follow_Desktop : MonoBehaviour
{
    public Transform cameraTransform;
    public float distance = 2f;

    void LateUpdate()
    {
        transform.position = cameraTransform.position + cameraTransform.forward * distance;
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTransform.position);
    }
}