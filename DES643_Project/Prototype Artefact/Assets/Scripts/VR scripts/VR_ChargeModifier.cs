using UnityEngine;

public class VR_ChargeModifier : MonoBehaviour
{
    public Transform rayOrigin;

    public float minCharge = 0.5f;
    public float maxCharge = 5f;
    public float speed = 2f;

    private Charge selectedCharge;

    void Update()
    {
        HandleSelection();
        HandleAdjustment();
        HandleDelete();
    }

    void HandleSelection()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Charge c = hit.collider.GetComponent<Charge>();

                if (c != null)
                {
                    if (c != selectedCharge)
                    {
                        Deselect();
                        selectedCharge = c;
                        SetGlow(c, true);
                        c.ShowText(true);
                    }
                }
            }
            else
            {
                Deselect();
            }
        }
    }

    void HandleAdjustment()
    {
        if (selectedCharge == null) return;

        float input = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        if (Mathf.Abs(input) > 0.2f)
        {
            float sign = Mathf.Sign(selectedCharge.chargeValue);
            float magnitude = Mathf.Abs(selectedCharge.chargeValue);

            magnitude += input * speed * Time.deltaTime;
            magnitude = Mathf.Clamp(magnitude, minCharge, maxCharge);

            selectedCharge.chargeValue = sign * magnitude;
            selectedCharge.UpdateVisual();
        }
    }

    void HandleDelete()
    {
        if (selectedCharge == null) return;

        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Destroy(selectedCharge.gameObject);
            selectedCharge = null;
        }
    }

    void Deselect()
    {
        if (selectedCharge != null)
        {
            SetGlow(selectedCharge, false);
            selectedCharge.ShowText(false);
            selectedCharge = null;
        }
    }

    void SetGlow(Charge c, bool state)
    {
        Renderer r = c.GetComponent<Renderer>();
        if (r == null) return;

        Material mat = r.material;

        if (state)
        {
            Color baseColor = mat.color;
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", baseColor * 2f);
        }
        else
        {
            mat.SetColor("_EmissionColor", Color.black);
        }
    }
}