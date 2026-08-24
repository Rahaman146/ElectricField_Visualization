using UnityEngine;

public class ElectricFieldManager : MonoBehaviour
{
    public float k = 1f; // scaled down constant

    public Vector3 CalculateField(Vector3 point)
    {
        Vector3 totalField = Vector3.zero;

        foreach (Charge charge in Charge.allCharges)
        {
            Vector3 r = point - charge.transform.position;

            float distance = r.magnitude + 0.01f; // avoid division by zero

            Vector3 field = (k * charge.chargeValue / (distance * distance)) * r.normalized;

            totalField += field;
        }

        return totalField;
    }
}