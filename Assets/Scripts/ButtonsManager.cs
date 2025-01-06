using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private GameObject EndScreen_main;
    [SerializeField] private GameObject About_main;

    // Start is called before the first frame update
    void Start()
    {
        About_main.SetActive(false);
        Time.timeScale = 0;
    }

    public void StartPlaying()
    {
        Time.timeScale = 1;
        Transform OpeningButton = gameObject.transform.Find("OpeningButton");
        OpeningButton.gameObject.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AboutSection()
    {
        EndScreen_main.SetActive(false);
        About_main.SetActive(true);
    }

    public void MainEndScreen()
    {
        EndScreen_main.SetActive(true);
        About_main.SetActive(false);
    }
}
