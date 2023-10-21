using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{   


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Mevcut Sahnenin indexi +1 olan sahneyi çaðýrýr yani oyun sahnemizi.
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
