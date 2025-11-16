using UnityEngine;

public class SubtractionQuestion : Question
{
    public SubtractionQuestion()
    {
        num1 = Random.Range(0, 101);
        num2 = Random.Range(0, num1+1);
        answer = num1 - num2;

        for (int i = 0; i < 2; i++)
        {
            int fakeAnswer = Random.Range(0, num1+1);
            fakeAnswers.Add(fakeAnswer);
        }
    }

    public override string GetSymbol() => "-";
}
