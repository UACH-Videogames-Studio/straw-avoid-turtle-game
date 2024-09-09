using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class TimeWaitScript : MonoBehaviour
{
    [SerializeField] float WaitTime;
    [SerializeField] TMP_Text TimeText;
    [SerializeField] Image WhiteCircle;
    [SerializeField] GameObject WaitPannel;
    [SerializeField] GameStatusController gameStatusController;
    private float currentTime = 0;
    void Start()
    {
        WhiteCircle.GetComponent<Image>();
        WhiteCircle.fillAmount = 0;
        Time.timeScale = 0;
    }
    void Update()
    {
        currentTime += Time.fixedDeltaTime;
        TimeText.text = currentTime.ToString("F1");
        WhiteCircle.fillAmount = currentTime / WaitTime;
        if (currentTime > WaitTime)
        {
            WaitPannel.SetActive(false);
            gameStatusController.ResumeGame();
        }
    }
}
