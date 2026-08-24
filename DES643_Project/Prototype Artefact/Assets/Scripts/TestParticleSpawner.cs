using UnityEngine;

public class TestParticleSpawner : MonoBehaviour
{
    public GameObject particlePrefab;
    public Transform playerCamera;
    public ElectricFieldManager fieldManager;

    public void SpawnParticle()
    {
        Vector3 spawnPos = playerCamera.position + playerCamera.forward * 2f;

        GameObject particle = Instantiate(particlePrefab, spawnPos, Quaternion.identity);

        TestParticle tp = particle.GetComponent<TestParticle>();
        tp.fieldManager = fieldManager;
    }
}