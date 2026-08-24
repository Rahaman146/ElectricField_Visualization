using UnityEngine;

public class HUD_Toggle_Desktop : MonoBehaviour
{
    public GameObject hud;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            hud.SetActive(!hud.activeSelf);
        }
    }
}