using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionTimer questionTimer;

    [SerializeField] private List<Button> answerButtons = new List<Button>();
    private List<TMP_Text> buttonsText = new List<TMP_Text>();
    private int product;

    private void Awake()
    {
        foreach (Button answerButton in answerButtons)
        {
            TMP_Text buttonText = answerButton.GetComponentInChildren<TMP_Text>();
            buttonsText.Add(buttonText);
            answerButton.onClick.AddListener(() => AnswerQuestion(buttonText));
        }
    }
    
    public void GenerateQuestion()
    {
        int multiplicand = UnityEngine.Random.Range(0, 13);
        int multiplier = UnityEngine.Random.Range(0, 13);
        product = multiplicand * multiplier;

        questionText.text = "What is " + multiplicand + " X " + multiplier;
        
        int answerChoice = UnityEngine.Random.Range(0, answerButtons.Count - 1);
        buttonsText[answerChoice].SetText(product.ToString());

        for (int i = 0; i < answerButtons.Count; i++)
        {
            if (i != answerChoice)
                buttonsText[i].SetText(UnityEngine.Random.Range(0, 145).ToString());
        }
    }

    public void AnswerQuestion(TMP_Text TMP)
    {
        if (TMP.text == product.ToString())
            print("Correct Answer");
        else
            print("Incorrect Answer");
        
        SetAnswerButtonsEnabled(false);
    }

    public void SetAnswerButtonsEnabled(bool enabled)
    {
        foreach (Button answerButton in answerButtons)
        {
            answerButton.enabled = enabled;
        }
    }
}
