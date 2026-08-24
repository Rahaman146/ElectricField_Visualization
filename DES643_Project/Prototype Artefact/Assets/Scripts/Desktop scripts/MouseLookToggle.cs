using UnityEngine;

public class MouseLookToggle : MonoBehaviour
{
    public MonoBehaviour mouseLookScript; // your camera rotation script

    private bool isFrozen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isFrozen = !isFrozen;

            if (mouseLookScript != null)
                mouseLookScript.enabled = !isFrozen;
        }
    }
}