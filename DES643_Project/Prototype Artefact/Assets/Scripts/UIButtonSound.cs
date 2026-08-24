using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerDownHandler
{
    public AudioSource audioSource;

    public void OnPointerDown(PointerEventData eventData)
    {
        // 🔥 Only play when actual press happens
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}