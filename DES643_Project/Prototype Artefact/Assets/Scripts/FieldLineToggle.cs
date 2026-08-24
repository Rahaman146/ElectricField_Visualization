using UnityEngine;
using TMPro;

public class FieldLineToggle : MonoBehaviour
{
    public GameObject fieldLines;
    public FieldLineGenerator fieldLineGenerator; // 🔥 strongly typed
    public TextMeshProUGUI buttonText;

    private bool isVisible = true;

    void Start()
    {
        UpdateButtonText();
    }

    public void ToggleFieldLines()
    {
        if (isVisible)
        {
            // 🔴 HIDE
            if (fieldLineGenerator != null)
            {
                fieldLineGenerator.enableFieldLines = false;
                fieldLineGenerator.ClearLines(); // remove existing lines
            }

            fieldLines.SetActive(false);
        }
        else
        {
            // 🟢 SHOW
            fieldLines.SetActive(true);

            if (fieldLineGenerator != null)
            {
                fieldLineGenerator.enableFieldLines = true;
            }
        }

        isVisible = !isVisible;
        UpdateButtonText();
    }

    void UpdateButtonText()
    {
        if (buttonText != null)
        {
            buttonText.text = isVisible ? "Hide\nField Lines" : "Show\nField Lines";
        }
    }

    // 🔥 Call this from RESET button also
    public void ForceHide()
    {
        if (fieldLineGenerator != null)
        {
            fieldLineGenerator.enableFieldLines = false;
            fieldLineGenerator.ClearLines();
        }

        fieldLines.SetActive(false);

        isVisible = false;
        UpdateButtonText();
    }
}