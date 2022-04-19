using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountAnswers : MonoBehaviour
{
    public static CountAnswers Instance;

    public int WrongAnswers;
    public int CorrectAnswers;

    public void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCorrect()
    {
        CorrectAnswers++;
    }

    public void IncreaseWrong()
    {
        WrongAnswers++;
    }
}
