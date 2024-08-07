using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplayPlayerName : MonoBehaviour
{
    public Text playerNameText; // UnityEngine.UI.Text
    private string filePath;

    void Start()
    {
        // Set file path
        filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        // Read JSON from file
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerData playerData = JsonUtility.FromJson<PlayerData>(json);

            // Display player name
            playerNameText.text = "Welcome, " + playerData.playerName;
        }
        else
        {
            playerNameText.text = "No player data found.";
        }
    }
}
