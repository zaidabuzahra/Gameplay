using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QT_Events : MonoBehaviour
{
    public static QT_Events Instance;
    public Text letter;

    public GameObject UIImage;
    public Image ShrinkingImage;

    private int RandomXPosition;
    private int RandomYPosition;
    public int Check = 1;

    [HideInInspector]
    public int LetterChoice;

    public int CheckValue;
    public int TimerValue;
    public int ShrinkValue;

    public float SetTimer;
    public float SetTimer1;
    public float SetTimer2;
    public float buttonTimer;

    [HideInInspector]
    public float ShrinkCircle;

    private bool bIsPressing = false;
    private bool bCanPress = true;
    private bool bUpdate = true;
    public bool bMoveBar = true;
    public bool bCheck = true;

    public AudioClip RightButtonAudio;
    public AudioClip WrongButtonAudio;

    // Start is called before the first frame update
    public void Awake()
    {
        Instance = this;
        if (ShrinkValue == 1)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(SetTimer, SetTimer, 0);
        }

        if (ShrinkValue == 2)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(SetTimer1, SetTimer1, 0);
        }

        if (ShrinkValue == 3)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(SetTimer2, SetTimer2, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bUpdate)
        {
            if (bCheck)
            {
                if (Check == 1)
                {
                    LetterChoice = ChosenLetter(1);
                    bCheck = false;
                }

                if (Check == 2)
                {
                    LetterChoice = ChosenLetter(2);
                    bCheck = false;
                }

                if (Check == 3)
                {
                    LetterChoice = ChosenLetter(3);
                    bCheck = false;
                }
            }

            if (bCanPress)
            {
                if (LetterChoice == 1)
                {
                    if (Input.GetKey("a"))
                    {
                        StartCoroutine(holdButton(SetTimer));
                        bIsPressing = true;

                        TimerValue = 1;
                        ShrinkValue = 2;
                        CheckValue = 2;
                    }

                    else if (Input.anyKeyDown)
                    {
                        if (!Input.GetKey("a"))
                        {
                            TimerValue = 1;
                            ShrinkValue = 2;
                            CheckValue = 2;
                            WrongA(2, ShrinkValue, TimerValue);
                        }
                    }

                    else
                    {
                        StopCoroutine(holdButton(SetTimer));

                        bIsPressing = false;
                        ShrinkCircle = 0;
                    }

                }

                if (LetterChoice == 2)
                {
                    if (Input.GetKey("d"))
                    {
                        StartCoroutine(holdButton(SetTimer1));
                        bIsPressing = true;

                        TimerValue = 2;
                        ShrinkValue = 3;
                        CheckValue = 3;
                    }

                    else if (Input.anyKeyDown)
                    {
                        if (!Input.GetKey("d"))
                        {
                            TimerValue = 2;
                            ShrinkValue = 3;
                            CheckValue = 3;
                            WrongA(3, ShrinkValue, TimerValue);
                        }
                    }

                    else
                    {
                        StopCoroutine(holdButton(SetTimer1));

                        bIsPressing = false;
                        ShrinkCircle = 0;
                    }

                }

                if (LetterChoice == 3)
                {
                    if (Input.GetKey("s"))
                    {
                        StartCoroutine(holdButton(SetTimer2));
                        bIsPressing = true;

                        TimerValue = 3;
                        ShrinkValue = 1;
                        CheckValue = 1;
                    }

                    else if (Input.anyKeyDown)
                    {
                        if (!Input.GetKey("s"))
                        {
                            TimerValue = 3;
                            ShrinkValue = 1;
                            CheckValue = 1;
                            WrongA(1, ShrinkValue, TimerValue);
                        }
                    }

                    else
                    {
                        StopCoroutine(holdButton(SetTimer2));

                        bIsPressing = false;
                        ShrinkCircle = 0;
                    }

                }
            }
            if (TimerValue == 1)
            {
                if (ShrinkCircle >= (SetTimer-1))
                {
                    bMoveBar = false;
                    ShowLetter(CheckValue, ShrinkValue, TimerValue);
                }
            }

            if (TimerValue == 2)
            {
                if (ShrinkCircle >= (SetTimer1 - 1))
                {
                    bMoveBar = false;
                    ShowLetter(CheckValue, ShrinkValue, TimerValue);
                }
            }

            if (TimerValue == 3)
            {
                if (ShrinkCircle >= (SetTimer2 - 1))
                {
                    bMoveBar = false;
                    ShowLetter(CheckValue, ShrinkValue, TimerValue);
                }
            }
        }
    }

    public int ChosenLetter(float RandomLetter)
    {
        RandomYPosition = Random.Range(150, 830);
        RandomXPosition = Random.Range(50, 1770);

        UIImage.GetComponent<Image>().transform.position = new Vector3(RandomXPosition, RandomYPosition, 0);


        if (RandomLetter == 1)
        {
            letter.text = "A";
            return 1;
        }

        if (RandomLetter == 2)
        {
            letter.text = "D";
            return 2;
        }

        if (RandomLetter == 3)
        {
            letter.text = "S";
            return 3;
        }

        return 4;
    }

    public void ShowLetter(int CheckVal, int TimeCheck, int Time)
    {
        CountAnswers.Instance.IncreaseCorrect();
        bCanPress = false;

        if (Time == 1)
        {
            StopCoroutine(holdButton(SetTimer));
        }

        if (Time == 2)
        {
            StopCoroutine(holdButton(SetTimer1));
        }

        if (Time == 3)
        {
            StopCoroutine(holdButton(SetTimer2));
        }


        bIsPressing = false;
        ShrinkCircle = 0;

        SoundManager.Instance.PlaySound(RightButtonAudio);
        StartCoroutine(TimeOut(0, CheckVal, TimeCheck));
    }

    public void WrongA(int CheckVal, int TimeCheck, float Timer)
    {
        CountAnswers.Instance.IncreaseWrong();
        bCanPress = false;

        
        if (Timer == 1)
        {
            StopCoroutine(holdButton(SetTimer));
        }

        if (Timer == 2)
        {
            StopCoroutine(holdButton(SetTimer1));
        }

        if (Timer == 3)
        {
            StopCoroutine(holdButton(SetTimer2));
        }

        bIsPressing = false;
        ShrinkCircle = 0;

        SoundManager.Instance.PlaySound(WrongButtonAudio);
        StartCoroutine(TimeOut(1, CheckVal, TimeCheck));
    }

    IEnumerator TimeOut(float animation, int CheckVal, int TimeCheck)
    {
        if (animation == 0)
        {
            UIImage.GetComponent<Animator>().Play("correctAnswer");
        }

        if (animation == 1)
        {
            UIImage.GetComponent<Animator>().Play("wrongAnswer");
        }

        yield return new WaitForSeconds(1);

        bIsPressing = false;
        bMoveBar = true;
        bCanPress = true;
        bCheck = true;

        ShrinkCircle = 0;
        Check = CheckVal;

        UIImage.GetComponent<Animator>().Play("Default");

        if (TimeCheck == 1)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(SetTimer, SetTimer, 0);
        }

        if (TimeCheck == 2)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(SetTimer1, SetTimer1, 0);
        }

        if (TimeCheck == 3)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(SetTimer2, SetTimer2, 0);
        }
    }

    IEnumerator holdButton(float Timer)
    {
        yield return new WaitForSeconds(buttonTimer);

        ShrinkCircle += 0.007f;
        if (bIsPressing)
        {
            ShrinkingImage.GetComponent<Image>().transform.localScale = new Vector3(Timer - ShrinkCircle, Timer - ShrinkCircle, 0);
        }
    }
}
