using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Transform cam;

    void Start()
    {
        if (Camera.main != null)
            cam = Camera.main.transform;
        else
            cam = FindObjectOfType<Camera>().transform;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        transform.rotation = Quaternion.LookRotation(
            transform.position - cam.position
        );
    }
}