using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public Image image; // UI Image za fade (mora biti preko cijelog ekrana)

    private void Start()
    {
        StartCoroutine(FadeOut()); // Fade-in efekat pri pokretanju scene
    }

    public void FadeAndLoad(string sceneName, float duration)
    {
        StartCoroutine(Fader(sceneName, duration));
    }

    IEnumerator Fader(string sceneName, float duration)
    {
        float t = 0;
        Color c = image.color;

        while (t < duration)
        {
            t += Time.deltaTime;
            c.a = t / duration;
            image.color = c;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator FadeOut()
    {
        float t = 0;
        Color c = image.color;

        while (t < 1)
        {
            t += Time.deltaTime;
            c.a = 1f - (t / 1f);
            image.color = c;
            yield return null;
        }
    }

    private void Update()
    {
        // Ako pritisneš tipku A — ideš na MainMenu
        if (Input.GetKeyDown(KeyCode.A))
        {
            FadeAndLoad("MainMenu", 1f);
        }

        // Ako pritisneš tipku B — ideš na AwakeningGrove
        if (Input.GetKeyDown(KeyCode.B))
        {
            FadeAndLoad("AwakeningGrove", 1f);
        }
    }
}
