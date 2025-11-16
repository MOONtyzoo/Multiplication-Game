using UnityEngine;

public class DivisionQuestion : Question
{
    public DivisionQuestion()
    {
        int random1 = Random.Range(0, 13);
        int random2 = Random.Range(0, 13);
        num1 = random1 * random2;
        num2 = Random.Range(0, 2)  == 0 ? random1 : random2;
        answer = num1 / num2;

        for (int i = 0; i < 2; i++)
        {
            int fakeAnswer = num2 + Random.Range(-5, 5);
            fakeAnswers.Add(fakeAnswer);
        }
    }

    public override string GetSymbol() => "/";
}
