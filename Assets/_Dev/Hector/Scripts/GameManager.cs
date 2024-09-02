using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public UnityEvent gameWon;
    [Range(0, 20)]
    [SerializeField] public int amountOfScreensForGameEnd;
    protected int screensPassedCounter = 0;


    public void ScreenHasBeenPassed()
    {
        screensPassedCounter++;
        CheckIfGameHasBeenWon();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

    private void CheckIfGameHasBeenWon()
    {
        if (screensPassedCounter == amountOfScreensForGameEnd)
            gameWon.Invoke();
    }
}
