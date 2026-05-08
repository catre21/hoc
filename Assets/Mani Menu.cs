using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    // Chơi đơn
    public void PlaySingle()
    {
        SceneManager.LoadScene("SinglePlayerScene");
    }

    // Chơi đội
    public void PlayMulti()
    {
        SceneManager.LoadScene("MultiPlayerScene");
    }

    // Mở cài đặt
    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    // Đóng cài đặt
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    // Thoát game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Thoát game");
    }
}
