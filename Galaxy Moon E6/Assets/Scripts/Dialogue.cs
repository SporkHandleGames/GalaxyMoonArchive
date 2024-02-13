using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    public int scene = 1;

    public string[] lines;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private string nextLine;
    private int curLine;
    public float timeBtwnChars;

    private bool isTyping;

    private void Start()
    {
        nextLine = lines[0];
        StopCoroutine(TypewriterText());
        StartCoroutine(TypewriterText());
    }

    public IEnumerator TypewriterText()
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in nextLine.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(timeBtwnChars);
        }

        isTyping = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && curLine < lines.Length && isTyping == false)
        {
            StopCoroutine(TypewriterText());
            curLine += 1;
            nextLine = lines[curLine];
            StartCoroutine(TypewriterText());
        }
    }
}
