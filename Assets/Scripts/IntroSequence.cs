using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroSequence : MonoBehaviour
{
    public Camera cam;
    public Transform player;
    public float zoomDuration = 2f;
    public float targetOrthographicSize = 2.5f;

    public CanvasGroup dialogBox;
    public Text dialogText;

    public string[] introLines;
    public float textDelay = 2f;

    void Start()
    {
        // Start intro
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        // Smooth Zoom-In
        float t = 0f;
        float startSize = cam.orthographicSize;

        while (t < zoomDuration)
        {
            t += Time.deltaTime;
            cam.orthographicSize = Mathf.Lerp(startSize, targetOrthographicSize, t / zoomDuration);
            cam.transform.position = new Vector3(player.position.x, player.position.y, -10f);
            yield return null;
        }

        // Show Dialog Box
        dialogBox.alpha = 1;
        dialogBox.interactable = true;
        dialogBox.blocksRaycasts = true;

        // Show Lines
        foreach (string line in introLines)
        {
            dialogText.text = line;
            yield return new WaitForSeconds(textDelay);
        }

        // Hide Dialog Box
        dialogBox.alpha = 0;
    }
}
