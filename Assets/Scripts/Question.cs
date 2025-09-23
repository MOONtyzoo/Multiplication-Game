using System.Collections.Generic;
using UnityEngine;

public abstract class Question
{
    protected int num1;
    protected int num2;
    protected int answer;
    protected List<int> fakeAnswers = new List<int>();

    public int GetNum1() => num1;
    public int GetNum2() => num2;
    public int GetAnswer() => answer;
    public List<int> GetFakeAnswers() => fakeAnswers;

    public abstract string GetSymbol();
}
