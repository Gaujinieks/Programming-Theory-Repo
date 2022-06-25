using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameOver;
    public TMP_Text winMessage;
    public bool isGameOver = false;
    public int coinAmount;
    private GameObject player;

    private void Start()
    {
        this.player = GameObject.FindWithTag("Player");// to get player game object
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver || !this.player)
        {
            GameOver();
        }

        if (coinAmount == 5)
        {
            winMessage.gameObject.SetActive(true);
            this.player.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

    }

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        gameOver.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
        isGameOver = false;
    }
}
