using UnityEngine;

public class AdditionQuestion : Question
{
    public AdditionQuestion()
    {
        num1 = Random.Range(0, 101);
        num2 = Random.Range(0, 101);
        answer = num1 + num2;

        for (int i = 0; i < 2; i++)
        {
            int fakeAnswer = Random.Range(0, 201);
            fakeAnswers.Add(fakeAnswer);
        }
    }

    public override string GetSymbol() => "+";
}
