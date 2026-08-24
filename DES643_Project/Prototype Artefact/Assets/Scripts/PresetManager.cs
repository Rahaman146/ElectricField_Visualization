using UnityEngine;

public class PresetManager : MonoBehaviour
{
    public Transform chargeParent;
    public GameObject positivePrefab;
    public GameObject negativePrefab;

    void ClearAll()
    {
        foreach (Charge c in FindObjectsOfType<Charge>())
        {
            Destroy(c.gameObject);
        }
        foreach (TestParticle tp in FindObjectsOfType<TestParticle>())
        {
            Destroy(tp.gameObject);
        }
    }

    public void ClearCharges()
    {
        ClearAll();
    }

    public void CreateDipole()
    {
        ClearAll();

        Vector3 center = new Vector3(0, 2.5f, 0);

        CreateCharge(positivePrefab, center + new Vector3(-1.5f, 0, 0), 1);
        CreateCharge(negativePrefab, center + new Vector3(1.5f, 0, 0), -1);
    }

    public void CreateQuadrupole()
    {
        ClearAll();

        Vector3 center = new Vector3(0, 2.5f, 0);

        CreateCharge(positivePrefab, center + new Vector3(-1.5f, 0, -1.5f), 1);
        CreateCharge(negativePrefab, center + new Vector3(1.5f, 0, -1.5f), -1);
        CreateCharge(positivePrefab, center + new Vector3(-1.5f, 0, 1.5f), 1);
        CreateCharge(negativePrefab, center + new Vector3(1.5f, 0, 1.5f), -1);
    }

    void CreateCharge(GameObject prefab, Vector3 pos, float value)
    {
        GameObject obj = Instantiate(prefab, pos, Quaternion.identity, chargeParent);

        Charge c = obj.GetComponent<Charge>();
        c.chargeValue = value;
    }
}