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
    private int correctAnswer;



    private void Awake()
    {
        answerButtons = new Button[] { answerButton1, answerButton2, answerButton3};
        buttonsText = new TMP_Text[answerButtons.Length];
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonsText[i] = answerButtons[i].GetComponentInChildren<TMP_Text>();
        }
        // I tried to instantiate these in the above for loop, but for some reason it the i would always be answerButtons.Length 
        answerButton1.onClick.AddListener(() => AnswerQuestion(buttonsText[0]));
        answerButton2.onClick.AddListener(() => AnswerQuestion(buttonsText[1]));
        answerButton3.onClick.AddListener(() => AnswerQuestion(buttonsText[2]));
    }
    public void GenerateQuestion()
    {
        int multiplicand = UnityEngine.Random.Range(0, 10);
        int multiplier = UnityEngine.Random.Range(0, 10);
        correctAnswer = multiplicand * multiplier;
        questionText.text = "What is " + multiplicand + " * " + multiplier;
        int answerChoice = UnityEngine.Random.Range(0, answerButtons.Length-1);
        buttonsText[answerChoice].SetText(correctAnswer.ToString());
        for (int i = 0; i < answerButtons.Length; i++)
        {
            if (i != answerChoice)
                buttonsText[i].SetText(UnityEngine.Random.Range(0, 100).ToString());
        }
    }

    public void AnswerQuestion(TMP_Text TMP)
    {
        if (TMP.text == correctAnswer.ToString())
            print("Correct Answer");
        else
            print("Incorrect Answer");
        DisableAnswers();

    }

    public void DisableAnswers()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].enabled = false;
        }
    }
}
