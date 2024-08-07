using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class MainMenuController : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button startButton;
    public Button quitButton;
    public TMP_Text highScoreText; // Use TMP_Text for high score

    private string filePath;

    void Start()
    {
        // Assign button click listeners
        startButton.onClick.AddListener(OnStartButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);

        // Set file path
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        // Load and display high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score : " + highScore;
    }

    void OnStartButtonClick()
    {
        // Get the text from the input field
        string playerName = nameInputField.text;

        // Create PlayerData object
        PlayerData playerData = new PlayerData { playerName = playerName };

        // Serialize PlayerData to JSON and write to file
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(filePath, json);

        // Load the next scene
        SceneManager.LoadScene(1);
    }

    void OnQuitButtonClick()
    {
        // Quit the application
        Application.Quit();

        // For editor mode
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
[System.Serializable]
public class PlayerData
{
    public string playerName;
}

