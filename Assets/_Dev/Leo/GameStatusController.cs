using UnityEngine;

public class GameStatusController : MonoBehaviour
{
    [SerializeField] GameObject PausePannel;
    void Start()
    {
        PausePannel.SetActive(false);    
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        PausePannel.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        PausePannel.SetActive(false);
    }
}