using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameData : MonoBehaviour
{
    public GameObject pausemenu;
    public GameObject overmenu;
    public float wavelength = 30f;
    float current;
    int currentwave = 1;
    public spawner sp;
    public TextMeshProUGUI WaveCounter;
    public float curve = 0.75f;

    void Start()
    {
        if (pausemenu != null)
        {
            pausemenu.SetActive(false);
        }
        if (overmenu != null)
        {
            overmenu.SetActive(false);
        }
        current = wavelength;
        WaveCounter.text = "Wave " + currentwave;
    }

    void FixedUpdate()
    {
        current -= Time.fixedDeltaTime;
        if (current <= 0)
        {
            current = wavelength;
            currentwave++;
            WaveCounter.text = "Wave " + currentwave;
            sp.rate *= curve;
        }
    }
    

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("Quit");
        Application.Quit();
    }

    public void GameOver()
    {
        overmenu.SetActive(true);
        Time.timeScale = 0;

    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
