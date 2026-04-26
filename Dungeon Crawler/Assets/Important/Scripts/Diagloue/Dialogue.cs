using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    public GameObject prompt;
    private bool ActivePrompt = true;

    private int index;
    
    void Start()
    {
        textComponent.text = string.Empty;
        StartDiagloue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if (ActivePrompt == true && Input.GetKeyDown(KeyCode.X))
        {
            Destroy(prompt);
            ActivePrompt = false;
        }
    }

    public void StartDiagloue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if (index <lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
