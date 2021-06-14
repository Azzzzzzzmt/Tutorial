using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text[] textGameObject;
    public GameObject[] textGameObjectsPanel;
    string[] text = new string[10];
    int howManyTimesClicked=0;
    int a = 0;

    private void Start()
    {
        howManyTimesClicked = 0;
        for(int i = 0; i < 10; i++)
        {
            text[0] = textGameObject[howManyTimesClicked].text;
            textGameObject[howManyTimesClicked].text = "";
        }
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Next();
        }
    }
    void Next()
    {
        Debug.Log(howManyTimesClicked+"__"+a);
        if (howManyTimesClicked > 0)
        {
            textGameObjectsPanel[howManyTimesClicked - 1].SetActive(false);
        }
        textGameObjectsPanel[howManyTimesClicked].SetActive(true);
        StartCoroutine(TextCoroutine(textGameObject[howManyTimesClicked]));
        howManyTimesClicked++;
    }
    IEnumerator TextCoroutine(Text TextGameObject)
    {
        foreach(char abc in text[howManyTimesClicked])
        {
            TextGameObject.text += abc;
            yield return new WaitForSeconds(0.06f);
        }
        Next();
    }
}
