using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
   public void QuitGame()
    {
        Application.Quit();
    }

    public void NextScene(int sceneChosen)
    {
        WaveManager.wavenumber = 0;
        WaveManager.wavemanagement = true;
        Time.timeScale = 1;
        DisplayBoss.enableBossBar = false;
        ScoreManager.Score = 0;
        SceneManager.LoadScene(sceneChosen);
        
    }
}
