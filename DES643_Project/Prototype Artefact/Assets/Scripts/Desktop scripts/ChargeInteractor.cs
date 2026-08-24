using UnityEngine;

public class ChargeInteractor : MonoBehaviour
{
    private Charge selectedCharge;

    public float scrollSpeed = 1f;
    public float minCharge = 0.5f;
    public float maxCharge = 5f;

    void Update()
    {
        HandleSelection();
        HandleScroll();
        HandleDelete();
    }

    // 🔷 Handle mouse click selection
    void HandleSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            bool clickedCharge = false;

            if (Physics.Raycast(ray, out hit))
            {
                Charge charge = hit.collider.GetComponent<Charge>();

                if (charge != null)
                {
                    clickedCharge = true;

                    if (selectedCharge != charge)
                    {
                        DeselectCurrent();

                        selectedCharge = charge;
                        SetGlow(selectedCharge, true);
                        selectedCharge.ShowText(true);
                    }
                }
            }

            // 🔷 Clicked empty space → deselect
            if (!clickedCharge)
            {
                DeselectCurrent();
            }
        }
    }

    // 🔷 Handle scroll to change magnitude
    void HandleScroll()
    {
        if (selectedCharge == null) return;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            float sign = Mathf.Sign(selectedCharge.chargeValue);
            float magnitude = Mathf.Abs(selectedCharge.chargeValue);

            magnitude += scroll * scrollSpeed;
            magnitude = Mathf.Clamp(magnitude, minCharge, maxCharge);

            selectedCharge.chargeValue = sign * magnitude;
            selectedCharge.UpdateVisual();
        }
    }

    void HandleDelete()
    {
        if (selectedCharge == null) return;

        // Press Delete key
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(selectedCharge.gameObject);
            selectedCharge = null;
        }
    }

    // 🔷 Deselect current charge
    void DeselectCurrent()
    {
        if (selectedCharge != null)
        {
            SetGlow(selectedCharge, false);
            selectedCharge.ShowText(false);
            selectedCharge = null;
        }
    }

    // 🔷 Glow using emission
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

    // 🔷 Optional: call this from drag script if needed
    public void ForceSelect(Charge c)
    {
        DeselectCurrent();

        selectedCharge = c;
        SetGlow(selectedCharge, true);
    }
}