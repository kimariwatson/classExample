using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int player2Score;

    public TMP_Text scoreText;
    public TMP_Text scoreText2;
    
    public GameObject gameOverScreen;

    public GameObject dayBackground;
    public GameObject nightBackground;

    private bool player1Alive = true;
    private bool player2Alive = true;  


    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd, string Player)
    {
        if (gameOverScreen.activeSelf != true)
        {
            switch (Player)
            {
                case ("Player 1"):
                    playerScore += scoreToAdd;
                    scoreText.text = (playerScore).ToString();
                    break;
                case ("Player 2"):
                    player2Score += scoreToAdd;
                    scoreText2.text = (player2Score).ToString();
                    break;
                default:
                    Debug.Log("There are no players");
                    break;
            }
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public bool checkAnyPlayersAlive()
    {
        return player1Alive || player2Alive;
    }

    public void playerDied(int playerNumber)
    {
        if(playerNumber==0)
        {
            player1Alive = false;
        }
        else if(playerNumber==1) 
        {
            player2Alive = false;
        }

        if(!checkAnyPlayersAlive())
        {
            gameOver();
        }
    }

}
