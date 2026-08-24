using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Charge : MonoBehaviour
{
    public float chargeValue = 1f;

    // 🔷 Visual scaling
    public float baseScale = 0.3f;
    public float scaleMultiplier = 0.2f;

    // 🔷 UI reference
    public GameObject textCanvas;              // 🔥 assign Canvas
    public TextMeshProUGUI chargeText;         // 🔥 assign TMP text

    // 🔷 All charges list
    public static List<Charge> allCharges = new List<Charge>();

    void OnEnable()
    {
        allCharges.Add(this);

        UpdateVisual();
        DisableGlow();

        ShowText(false); // 🔥 hide initially
    }

    void OnDisable()
    {
        allCharges.Remove(this);
    }

    // 🔷 Update size + text
    public void UpdateVisual()
    {
        float magnitude = Mathf.Abs(chargeValue);

        float scale = baseScale + magnitude * scaleMultiplier;
        transform.localScale = new Vector3(scale, scale, scale);

        // 🔷 Update text
        if (chargeText != null)
        {
            string sign = chargeValue > 0 ? "+" : "";
            chargeText.text = sign + chargeValue.ToString("F1") + " C";

            // 🔷 Color based on sign
            chargeText.color = chargeValue > 0 ? Color.red : Color.blue;
        }
    }

    // 🔷 Glow OFF
    public void DisableGlow()
    {
        Renderer r = GetComponent<Renderer>();

        if (r != null)
        {
            Material mat = r.material;
            mat.SetColor("_EmissionColor", Color.black);
        }
    }

    // 🔷 Show / Hide text
    public void ShowText(bool state)
    {
        if (textCanvas != null)
        {
            textCanvas.SetActive(state);
        }
    }
}