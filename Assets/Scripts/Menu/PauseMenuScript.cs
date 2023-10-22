using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    [field: SerializeField] public PlayerDamageHandler DamageHandler { get; private set; }

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject LoseUI;
    public GameObject WinUI;
    public Text _ammoText;

    private void OnEnable()
    {
        DamageHandler.OnDie += HandleDie;
    }
    private void OnDisable()
    {
        DamageHandler.OnDie -= HandleDie;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) 
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Reload()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void HandleDie()
    {
        LoseUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UpdateAmmo(int ammoCount)
    {
        _ammoText.text = ""+ammoCount;
    }
}
