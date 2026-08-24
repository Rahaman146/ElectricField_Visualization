using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject hud;
    public Transform playerCamera;

    public float distance = 2f;

    private bool isVisible = false;

    void Start()
    {
        hud.SetActive(false);
    }

    void Update()
    {
        // 🔷 TAB toggle only
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isVisible = !isVisible;
            hud.SetActive(isVisible);
        }
    }

    void LateUpdate()
    {
        if (!hud.activeSelf) return;

        // 🔷 Smooth follow (same as your old script)
        hud.transform.position =
            playerCamera.position + playerCamera.forward * distance;

        hud.transform.rotation =
            Quaternion.LookRotation(hud.transform.position - playerCamera.position);
    }
}