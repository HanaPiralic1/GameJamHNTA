using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleDialog : MonoBehaviour
{
    public TMP_Text dialogText;
    public string[] lines = { "dr", "br", "bla"};
    int index = 0;

    void Start()
    {
        dialogText.text = lines[index];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            index++;
            if (index < lines.Length)
                dialogText.text = lines[index];
            else
                dialogText.gameObject.SetActive(false); // Sakrij Text kad završi
        }
    }
}
