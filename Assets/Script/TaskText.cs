using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskText : MonoBehaviour
{
    public static TaskText Instance;

    public string TextA;
    public string TextD;
    public string TextS;
    public Text TextBox;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (QT_Events.Instance.LetterChoice == 1)
        {
            TextBox.text = TextA;
        }

        if (QT_Events.Instance.LetterChoice == 2)
        {
            TextBox.text = TextD;
        }

        if (QT_Events.Instance.LetterChoice == 3)
        {
            TextBox.text = TextS;
        }
    }

}
