using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionTimer questionTimer;
    [SerializeField] private Button answerButton1;
    [SerializeField] private Button answerButton2;
    [SerializeField] private Button answerButton3;

    private Button[] answerButtons;
    private TMP_Text[] buttonsText;
    private int product;

    private void Awake()
    {
        answerButtons = new Button[] { answerButton1, answerButton2, answerButton3};
        buttonsText = new TMP_Text[answerButtons.Length];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();
            buttonsText[i] = buttonText;
            answerButtons[i].onClick.AddListener(() => AnswerQuestion(buttonText));
        }
    }
    
    public void GenerateQuestion()
    {
        int multiplicand = UnityEngine.Random.Range(0, 13);
        int multiplier = UnityEngine.Random.Range(0, 13);
        product = multiplicand * multiplier;

        questionText.text = "What is " + multiplicand + " * " + multiplier;
        
        int answerChoice = UnityEngine.Random.Range(0, answerButtons.Length - 1);
        buttonsText[answerChoice].SetText(product.ToString());

        for (int i = 0; i < answerButtons.Length; i++)
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
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].enabled = enabled;
        }
    }
}
