using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text gameOver;
    public bool isGameOver = false;
    public int coinAmount;
    private GameObject player;
    private AudioSource audianceCheering;
    private bool levelFinished = false;

    private void Start()
    {
        this.player = GameObject.FindWithTag("Player");// to get player game object
        audianceCheering = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GameState();
    }
    // ABSTRACTION >>
    private void GameState()
    {
        if (isGameOver || !this.player)
        {
            GameOver();
        }

        if (coinAmount == 5 && !audianceCheering.isPlaying && !levelFinished)
        {
            audianceCheering.Play();
            this.player.SetActive(false);
            levelFinished = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
    // ABSTRACTION <<

    public void GameOver()
    {
        gameOver.gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        gameOver.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
        isGameOver = false;
    }
}
