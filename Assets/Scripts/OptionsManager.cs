using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("OptionButtons")]
    [Space]
    [SerializeField] private NumQuestionsOption[] numQuestionsOptions;
    [SerializeField] private TextMeshProUGUI numQuestionsText;
    [Space]
    [SerializeField] private QuizTypeOption[] quizTypeOptions;
    [SerializeField] private TextMeshProUGUI quizTypeText;

    public class Options
    {
        public int numQuestions = 3;
        public QuizManager.QuizTypes quizType = QuizManager.QuizTypes.All;
    }
    public Options options = new();
    
    [Serializable]
    private struct NumQuestionsOption
    {
        public Button button;
        public int value;
    }

    [Serializable]
    private struct QuizTypeOption
    {
        public Button button;
        public QuizManager.QuizTypes value;
    }

    private void Awake()
    {
        foreach (NumQuestionsOption option in numQuestionsOptions)
        {
            option.button.onClick.AddListener(() => OnNumQuestionsOptionClicked(option));
        }

        foreach (QuizTypeOption option in quizTypeOptions)
        {
            option.button.onClick.AddListener(() => OnQuizTypeOptionClicked(option));
        }
        
        UpdateText();
    }

    private void OnNumQuestionsOptionClicked(NumQuestionsOption option)
    {
        options.numQuestions = option.value;
        UpdateText();
    }

    private void OnQuizTypeOptionClicked(QuizTypeOption option)
    {
        options.quizType = option.value;
        UpdateText();
    }

    private void UpdateText()
    {
        numQuestionsText.text = $"Number of Questions: {options.numQuestions}";
        quizTypeText.text = $"Quiz Type: {options.quizType.ToString()}";
    }
}
