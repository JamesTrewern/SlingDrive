using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameMenu : MonoBehaviour
{
    private PublicVariables Variables;
    private int ScoreAsInt;
    private void Start()
    {
        Variables = this.GetComponent<PublicVariables>();
        ScoreAsInt = (int)Mathf.Round(Variables.GetScore());
        DisplayScore(ScoreAsInt);
    }

    public TextMeshProUGUI ScoreDisplay;
    public void RetryGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void DisplayScore (int Score)
    {
        ScoreDisplay.text = Score.ToString();
    }
}
