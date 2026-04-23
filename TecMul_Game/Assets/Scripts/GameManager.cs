using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject victoryScreen;

    private void Awake()
    {
        // Singleton para aceder ao GameManager de qualquer script
        if (Instance == null)
            Instance = this;
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f; // Pausa o jogo
        Cursor.lockState = CursorLockMode.None; // Liberta o cursor
        Cursor.visible = true;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f; // Repõe o tempo antes de mudar de cena
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}