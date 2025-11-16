using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    [Header("OptionButtons")]
    [SerializeField] private NumQuestionsOption[] numQuestionsOptions;
    [SerializeField] private QuizTypeOption[] quizTypeOptions;

    public class Options
    {
        public int numQuestions;
        public QuizManager.QuizTypes quizType;
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
    }

    private void OnNumQuestionsOptionClicked(NumQuestionsOption option)
    {
        options.numQuestions = option.value;
    }

    private void OnQuizTypeOptionClicked(QuizTypeOption option)
    {
        options.quizType = option.value;
    }
}
