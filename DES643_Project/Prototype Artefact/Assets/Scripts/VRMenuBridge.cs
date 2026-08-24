using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using SlimUI.ModernMenu;

public class VRMenuBridge : MonoBehaviour
{
    public GameObject canvMain;
    public GameObject canvOptions;
    public GameObject canvManual;
    public UIMenuManager menuManager;

    [Header("Animation Settings")]
    public float animDuration = 0.2f;
    public AudioSource swooshSound;

    [Header("Loading Screen")]
    public GameObject loadingMenu;        // drag Loading object here
    public Slider loadingBar;             // drag ProgressBar slider here
    public TMP_Text loadingText;          // drag LoadingText here
    public TMP_Text promptText;           // drag TextPrompt here
    public bool waitForInput = true;
    public KeyCode promptKey = KeyCode.Return;

    public void OpenSettings()
    {
        menuManager.Position2();
        canvMain.SetActive(false);
        canvOptions.SetActive(true);
        if (swooshSound) swooshSound.Play();
        StartCoroutine(SlideIn(canvOptions));
    }

    public void CloseSettings()
    {
        menuManager.Position1();
        StartCoroutine(SlideOut(canvOptions, () =>
        {
            canvOptions.SetActive(false);
            canvMain.SetActive(true);
            StartCoroutine(SlideIn(canvMain));
        }));
    }

    public void EnterVRLab()
    {
        if (swooshSound) swooshSound.Play();
        StartCoroutine(SlideOut(canvMain, () =>
        {
            canvMain.SetActive(false);
            loadingMenu.SetActive(true);
            StartCoroutine(LoadScene("Lab_Scene"));
        }));
    }

    IEnumerator LoadScene(string sceneName)
    {
        loadingBar.value = 0;
        loadingText.text = "LOADING...";
        promptText.gameObject.SetActive(false);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBar.value = Mathf.MoveTowards(
                loadingBar.value, progress, Time.deltaTime * 0.5f);

            loadingText.text = "LOADING... " + Mathf.RoundToInt(progress * 100) + "%";

            if (operation.progress >= 0.9f)
            {
                loadingBar.value = 1;
                loadingText.text = "READY";
                yield return new WaitForSeconds(0.5f); // brief pause on READY
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    IEnumerator SlideIn(GameObject canvas)
    {
        Vector3 original = canvas.transform.localScale;
        canvas.transform.localScale = Vector3.zero;

        float elapsed = 0f;
        while (elapsed < animDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / animDuration);
            canvas.transform.localScale = Vector3.Lerp(Vector3.zero, original, t);
            yield return null;
        }
        canvas.transform.localScale = original;
    }

    IEnumerator SlideOut(GameObject canvas, System.Action onDone)
    {
        Vector3 original = canvas.transform.localScale;
        float elapsed = 0f;
        while (elapsed < animDuration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.SmoothStep(0f, 1f, elapsed / animDuration);
            canvas.transform.localScale = Vector3.Lerp(original, Vector3.zero, t);
            yield return null;
        }
        canvas.transform.localScale = original;
        onDone?.Invoke();
    }

    public void OpenManual()
    {
        canvMain.SetActive(false);
        canvManual.SetActive(true);
        if (swooshSound) swooshSound.Play();
        StartCoroutine(SlideIn(canvManual));
    }

    public void CloseManual()
    {
        StartCoroutine(SlideOut(canvManual, () =>
        {
            canvManual.SetActive(false);
            canvMain.SetActive(true);
            StartCoroutine(SlideIn(canvMain));
        }));
    }

}