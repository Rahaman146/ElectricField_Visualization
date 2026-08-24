using UnityEngine;

public class HUDPageManager : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;

    void Start()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }

    public void GoToPage2()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }

    public void GoToPage1()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }
}