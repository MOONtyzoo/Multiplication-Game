using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private QuestionTimer questionTimer;
    [SerializeField] private GameObject questionPanel;
    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private List<Button> answerButtons = new List<Button>();

    [SerializeField] private int questionSetSize = 3;
    private List<Question> questionSet = new List<Question>();
    private int? submittedAnswer;

    private int questionsAnswered = 0;
    private int questionsAnsweredCorrectly = 0;

    private bool answerSubmittedEventCheck = false;
    private bool timerCompletedEventCheck = false;

    private Coroutine quizCoroutine;
    private int totalTimeTaken = 0;

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
        if (quizCoroutine != null) StopCoroutine(quizCoroutine);
        quizCoroutine = StartCoroutine(QuizCoroutine());
    }

    private IEnumerator QuizCoroutine()
    {
        questionPanel.SetActive(true);
        resultText.gameObject.SetActive(false);

        GenerateQuestionSet();
        questionsAnswered = 0;
        questionsAnsweredCorrectly = 0;

        foreach (Question question in questionSet)
        {
            LoadQuestion(question);
            questionTimer.StartCountdown();

            /*
                I wanted to pause the coroutine until one of these events occurs
                Unfortunately you can't wait for an event directly, so I had to do
                it indrectly using the "EventCheck" boolean variables
            */
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
        questionPanel.SetActive(false);
        resultText.gameObject.SetActive(true);
        resultText.text = "You got " + questionsAnsweredCorrectly + " / " + questionsAnswered + " questions correct!";
    }

    private void GenerateQuestionSet()
    {
        questionSet.Clear();
        for (int i = 0; i < questionSetSize; i++)
        {
            Question newQuestion = new MultiplicationQuestion();
            questionSet.Add(newQuestion);
        }
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
