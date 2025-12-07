using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField mainMenuPlayerNameText;

    private void Awake()
    {
        if (string.IsNullOrEmpty(SaveManager.Instance.saveData.LatestPlayerName))
        {
            mainMenuPlayerNameText.text = "";
        }
        else
        {
            mainMenuPlayerNameText.text = SaveManager.Instance.saveData.LatestPlayerName;
        }
    }

    public void StartGame()
    {
        var playerNameInputBoxOutline = GameObject.Find("MenuCanvas/MenuPanel/PlayerNameInput").GetComponent<Outline>();
        if (string.IsNullOrEmpty(mainMenuPlayerNameText.text))
        {
            playerNameInputBoxOutline.enabled = true;
            return;
        }
        else
        {
            playerNameInputBoxOutline.enabled = false;
        }

        SaveManager.Instance.saveData.LatestPlayerName = mainMenuPlayerNameText.text;
        SaveManager.Instance.SaveGame();
        SceneManager.LoadScene(1);
    }
}
