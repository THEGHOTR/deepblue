using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public string sentence;

    public float typingSpeed = 0.0001f;

    public Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeSentence(sentence));

        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(text.color.a <= 0)
        {
            text.enabled = false;
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        text.text = "";
        yield return new WaitForSeconds(5);
        
        foreach(char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(5);
        StartCoroutine(FadeText(1f, text)); ;
    }

    IEnumerator FadeText(float t, Text i)
    {
        while (true)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
