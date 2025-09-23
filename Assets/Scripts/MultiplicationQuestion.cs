using UnityEngine;

public class MultiplicationQuestion : Question
{
    public MultiplicationQuestion()
    {
        num1 = Random.Range(0, 13);
        num2 = Random.Range(0, 13);
        answer = num1 * num2;

        for (int i = 0; i < 2; i++)
        {
            int fakeAnswer = Random.Range(0, 145);
            fakeAnswers.Add(fakeAnswer);
        }
    }

    public override string GetSymbol() => "*";
}
