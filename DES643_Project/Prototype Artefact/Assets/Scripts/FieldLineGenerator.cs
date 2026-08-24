using UnityEngine;
using System.Collections.Generic;

public class FieldLineGenerator : MonoBehaviour
{
    public ElectricFieldManager fieldManager;
    public GameObject linePrefab;
    public Transform fieldLinesParent;

    public int numberOfLines = 30;
    public float baseStepSize = 0.2f;
    public int maxSteps = 120;
    public float stopThreshold = 0.3f;

    public bool enableFieldLines = true; // 🔥 CONTROL FLAG

    private List<GameObject> allLines = new List<GameObject>();

    void Update()
    {
        if (!enableFieldLines) return;

        ClearLines();
        GenerateLines();
    }

    public void GenerateLines()
    {
        foreach (Charge charge in Charge.allCharges)
        {
            if (charge.chargeValue <= 0) continue;

            List<Vector3> directions = GenerateSphereDirections(numberOfLines);

            foreach (Vector3 dir in directions)
            {
                Vector3 startPos = charge.transform.position + dir * 0.5f;
                CreateLine(startPos);
            }
        }
    }

    List<Vector3> GenerateSphereDirections(int n)
    {
        List<Vector3> dirs = new List<Vector3>();

        float goldenRatio = (1 + Mathf.Sqrt(5)) / 2;
        float angleIncrement = 2 * Mathf.PI * goldenRatio;

        for (int i = 0; i < n; i++)
        {
            float t = (float)i / n;

            float inclination = Mathf.Acos(1 - 2 * t);
            float azimuth = angleIncrement * i;

            float x = Mathf.Sin(inclination) * Mathf.Cos(azimuth);
            float y = Mathf.Sin(inclination) * Mathf.Sin(azimuth);
            float z = Mathf.Cos(inclination);

            dirs.Add(new Vector3(x, y, z));
        }

        return dirs;
    }

    void CreateLine(Vector3 startPos)
    {
        // 🔥 IMPORTANT: parent correctly
        GameObject lineObj = Instantiate(linePrefab, fieldLinesParent);

        LineRenderer lr = lineObj.GetComponent<LineRenderer>();

        List<Vector3> points = new List<Vector3>();
        Vector3 currentPos = startPos;

        for (int i = 0; i < maxSteps; i++)
        {
            points.Add(currentPos);

            Vector3 field = fieldManager.CalculateField(currentPos);

            if (field.magnitude < 0.01f)
                break;

            foreach (Charge c in Charge.allCharges)
            {
                if (c.chargeValue < 0)
                {
                    float dist = Vector3.Distance(currentPos, c.transform.position);

                    if (dist < stopThreshold)
                    {
                        points.Add(c.transform.position);
                        goto EndLine;
                    }
                }
            }

            float dynamicStep = baseStepSize / (1 + field.magnitude * 0.5f);
            currentPos += field.normalized * dynamicStep;
        }

    EndLine:

        lr.positionCount = points.Count;
        lr.SetPositions(points.ToArray());

        allLines.Add(lineObj);
    }

    public void ClearLines()
    {
        foreach (GameObject line in allLines)
        {
            if (line != null)
                Destroy(line);
        }
        allLines.Clear();
    }
}