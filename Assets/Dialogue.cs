using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    
    private string[] lines;
    private int index;

    void Start()
    {
        textComponent.text = string.Empty;
        gameObject.SetActive(false); // Sembunyikan dialog di awal
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    public void StartDialogue(string[] newLines)
    {
        gameObject.SetActive(true); // Munculkan UI dialog
        lines = newLines;
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // Sembunyikan dialog setelah selesai
        }
    }
}
