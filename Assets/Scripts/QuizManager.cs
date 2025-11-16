using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private OptionsManager optionsManager;
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionTimer questionTimer;
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private List<Button> answerButtons = new List<Button>();
    
    private List<Question> questionSet = new List<Question>();
    private int? submittedAnswer;

    private int questionsAnswered = 0;
    private int questionsAnsweredCorrectly = 0;

    private bool answerSubmittedEventCheck = false;
    private bool timerCompletedEventCheck = false;

    private Coroutine quizCoroutine;
    private int totalTimeTaken = 0;

    public enum QuizTypes
    {
        Addition, Subtraction, Multiplication, Division, All
    }

    private void Awake()
    {
        foreach (Button button in answerButtons)
        {
            button.onClick.AddListener(() => OnAnswerButtonClicked(button));
        }

        questionTimer.OnCountdownCompleted += OnQuestionTimerCompleted;
    }

    private void OnAnswerButtonClicked(Button button)
    {
        submittedAnswer = int.Parse(button.GetComponentInChildren<TMP_Text>().text);
        answerSubmittedEventCheck = true;
    }

    private void OnQuestionTimerCompleted()
    {
        submittedAnswer = null;
        timerCompletedEventCheck = true;
    }

    public void StartQuiz()
    {
        answerSubmittedEventCheck = false;
        timerCompletedEventCheck = false;
        if (quizCoroutine != null) StopCoroutine(quizCoroutine);
        quizCoroutine = StartCoroutine(QuizCoroutine());
    }

    public void StopQuiz()
    {
        StopCoroutine(QuizCoroutine());
    }

    private IEnumerator QuizCoroutine()
    {
        GenerateQuestionSet();
        questionsAnswered = 0;
        questionsAnsweredCorrectly = 0;

        foreach (Question question in questionSet)
        {
            LoadQuestion(question);
            questionTimer.StartCountdown();
            
            yield return new WaitUntil(() => answerSubmittedEventCheck || timerCompletedEventCheck);
            answerSubmittedEventCheck = false;
            timerCompletedEventCheck = false;

            questionsAnswered++;
            bool answeredCorrectly = submittedAnswer == question.GetAnswer();
            if (answeredCorrectly) questionsAnsweredCorrectly++;
            AchievementEvents.OnQuestionAnswered.Invoke(new AchievementEvents.OnQuestionAnsweredArgs
            {
                AnsweredCorrectly = answeredCorrectly,
                TimeRemaining = questionTimer.GetTimeRemaining(),
            });
            totalTimeTaken += (10 - questionTimer.GetTimeRemaining());
        }

        AchievementEvents.OnRoundEnded.Invoke(new AchievementEvents.OnRoundEndedArgs
        {
            NumQuestionsAnswered = questionsAnswered,
            NumCorrectQuestions = questionsAnsweredCorrectly,
            TotalTimeTaken = totalTimeTaken
        });
    }

    private void GenerateQuestionSet()
    {
        questionSet.Clear();
        for (int i = 0; i < optionsManager.options.numQuestions; i++)
        {
            Question newQuestion = GenerateQuestion();
            questionSet.Add(newQuestion);
        }
    }

    private Question GenerateQuestion()
    {
        switch (optionsManager.options.quizType)
        {
            case QuizTypes.Addition: return new AdditionQuestion();
            case QuizTypes.Subtraction: return new SubtractionQuestion();
            case QuizTypes.Multiplication: return new MultiplicationQuestion();
            case QuizTypes.Division: return new DivisionQuestion();
            case QuizTypes.All: return GenerateRandomQuestion();
        }
        
        return null;
    }

    private Question GenerateRandomQuestion()
    {
        int randomChoice = Random.Range(0, 4);
        switch (randomChoice)
        {
            case 0: return new AdditionQuestion();
            case 1: return new SubtractionQuestion();
            case 2: return new MultiplicationQuestion();
            case 3: return new DivisionQuestion();
        }
        return null;
    }

    private void LoadQuestion(Question question)
    {
        questionPanel.SetActive(true);
        questionText.text = "What is " + question.GetNum1() + " " + question.GetSymbol() + " " + question.GetNum2() + "?";

        int correctButtonIdx = Random.Range(0, answerButtons.Count);
        int fakeAnswerIdx = 0;
        for (int i = 0; i < answerButtons.Count; i++)
        {
            TMP_Text buttonText = answerButtons[i].GetComponentInChildren<TMP_Text>();

            if (i == correctButtonIdx)
            {
                buttonText.text = question.GetAnswer().ToString();
            }
            else
            {
                buttonText.text = question.GetFakeAnswers()[fakeAnswerIdx++].ToString();
            }
        }
    }
}
