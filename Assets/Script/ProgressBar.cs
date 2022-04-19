using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private bool bProgressBar, bHoldBar;

    public Image TopBar;
    public Image BottomBar;

    private float time;
    private float Divide;

    public int levelDuration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bProgressBar)
        {
            time += Time.deltaTime / levelDuration;
            TopBar.GetComponent<Image>().fillAmount = time;

            if (TopBar.GetComponent<Image>().fillAmount >= 1)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }

        if (bHoldBar)
        {
            if (QT_Events.Instance.TimerValue == 1)
            {
                Divide = 40 / QT_Events.Instance.SetTimer;
            }

            if (QT_Events.Instance.TimerValue == 2)
            {
                Divide = 40 / QT_Events.Instance.SetTimer1;
            }

            if (QT_Events.Instance.TimerValue == 3)
            {
                Divide = 40 / QT_Events.Instance.SetTimer2;
            }
             
            if (QT_Events.Instance.bMoveBar)
            {
                BottomBar.GetComponent<Image>().transform.localScale = new Vector3 (QT_Events.Instance.ShrinkCircle * Divide , 1, 0);
            }
            else 
            {
                BottomBar.GetComponent<Image>().transform.localScale = new Vector3(35, 1, 0);
            }
        }
    }
}
