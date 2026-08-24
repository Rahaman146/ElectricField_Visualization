using UnityEngine;

public class FieldDebugger : MonoBehaviour
{
    public ElectricFieldManager fieldManager;

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Vector3 point = transform.position;

            Vector3 field = fieldManager.CalculateField(point);

            Debug.Log("Field = " + field);

            Debug.DrawRay(point, field * 5f, Color.green, 2f);
        }
    }
}