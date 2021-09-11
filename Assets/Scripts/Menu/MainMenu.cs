using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonPlay;
    [SerializeField] private Button _buttonSetting;
    [SerializeField] private Button _buttonExit;

    private void OnEnable()
    {
        _buttonPlay.onClick.AddListener(PlayGame);
        _buttonExit.onClick.AddListener(ExitGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
