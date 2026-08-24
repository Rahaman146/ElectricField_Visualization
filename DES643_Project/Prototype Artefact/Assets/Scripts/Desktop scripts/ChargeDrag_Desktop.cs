using UnityEngine;

public class ChargeDrag_Desktop : MonoBehaviour
{
    private bool isDragging = false;
    private float distanceToCamera;

    void OnMouseDown()
    {
        distanceToCamera = Vector3.Distance(
            transform.position,
            Camera.main.transform.position
        );

        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Vector3 newPosition = ray.GetPoint(distanceToCamera);

            transform.position = newPosition;
        }
    }
}