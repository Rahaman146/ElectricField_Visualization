using UnityEngine;

public class VR_HUD_Toggle : MonoBehaviour
{
    public GameObject hud;

    void Start()
    {
        hud.SetActive(false);
    }

    void Update()
    {
        // 🔷 Toggle HUD using B button
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            hud.SetActive(!hud.activeSelf);
        }
    }
}