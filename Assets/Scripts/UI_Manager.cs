using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{

    public Text ValueTxt;

    private Button Button_Quit;

    public Button BackButton;

    private void Start()
    {
        BackButton = Singleton.Instance.Value;
    }

    public void UIReferences()
    {
        Button_Quit = GameObject.Find("Button_Quit").GetComponent<Button>();
        Button_Quit.onClick.AddListener(QuitGame);
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene("About_Scene");

    }

    public void GoToMain()
    {
        SceneManager.LoadScene("Main_Scene");
    }

    public void GoToPlay()
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void GoToRollCharacter()
    {
        SceneManager.LoadScene("Roll_Character_Scene");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings_Scene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
