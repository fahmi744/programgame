using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game keluar (di editor gak kelihatan)");
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll(); // hapus save lama, mulai dari awal
        PlayerPrefs.Save();
        SceneManager.LoadScene("gameplayscene");
    }

    public void Play()
    {
        // hanya bisa lanjut kalau ada save
        if (PlayerPrefs.GetInt("HasSave", 0) == 1)
        {
            SceneManager.LoadScene("gameplayscene");
        }
        else
        {
            Debug.Log("Belum ada save!");
        }
    }
}