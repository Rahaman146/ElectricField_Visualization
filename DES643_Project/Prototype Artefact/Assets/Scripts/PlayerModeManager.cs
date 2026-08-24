using UnityEngine;

public class PlayerModeManager : MonoBehaviour
{
    [Header("Players")]
    public GameObject ovrRig;
    public GameObject desktopPlayer;

    [Header("Desktop Scripts")]
    public MonoBehaviour chargeInteractor;
    public MonoBehaviour hudFollowDesktop;

    [Header("VR Scripts")]
    public VR_ChargeModifier vrChargeModifier;
    public VR_HUD_Toggle vrHUDToggle;

    [Header("HUD")]
    public GameObject hud;

    void Start()
    {
        // 🔷 Change this to switch mode
        bool useVR = false; // 👉 SET TRUE FOR VR MODE

        if (useVR)
        {
            EnableVRMode();
        }
        else
        {
            EnableDesktopMode();
        }
    }

    void EnableDesktopMode()
    {
        // Players
        ovrRig.SetActive(false);
        desktopPlayer.SetActive(true);

        // Desktop scripts
        if (chargeInteractor != null) chargeInteractor.enabled = true;
        if (hudFollowDesktop != null) hudFollowDesktop.enabled = true;

        // VR scripts
        if (vrChargeModifier != null) vrChargeModifier.enabled = false;
        if (vrHUDToggle != null) vrHUDToggle.enabled = false;

        Debug.Log("Desktop Mode Enabled");
    }

    void EnableVRMode()
    {
        // Players
        ovrRig.SetActive(true);
        desktopPlayer.SetActive(false);

        // Desktop scripts
        if (chargeInteractor != null) chargeInteractor.enabled = false;
        if (hudFollowDesktop != null) hudFollowDesktop.enabled = false;

        // VR scripts
        if (vrChargeModifier != null) vrChargeModifier.enabled = true;
        if (vrHUDToggle != null) vrHUDToggle.enabled = true;

        Debug.Log("VR Mode Enabled");
    }
}