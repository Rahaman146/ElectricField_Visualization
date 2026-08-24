using UnityEngine;

public class ChargeSpawner_Desktop : MonoBehaviour
{
    public GameObject positivePrefab;
    public GameObject negativePrefab;

    public Transform cameraTransform;
    public float spawnDistance = 2f;

    public void SpawnPositive()
    {
        SpawnCharge(positivePrefab);
    }

    public void SpawnNegative()
    {
        SpawnCharge(negativePrefab);
    }

    void SpawnCharge(GameObject prefab)
    {
        if (cameraTransform == null) return;

        Vector3 spawnPos = cameraTransform.position + cameraTransform.forward * spawnDistance;

        Instantiate(prefab, spawnPos, Quaternion.identity);
    }
}