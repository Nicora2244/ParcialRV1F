using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerNameManager : MonoBehaviour
{
    public static PlayerNameManager instance;

    public TMP_InputField nameInputField;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Asignar el evento de finalización de edición al campo de texto
        nameInputField.onEndEdit.AddListener(OnNameInputEndEdit);
    }

    private void OnNameInputEndEdit(string playerName)
    {
        SavePlayerName(); // Guardar el nombre del jugador

        // Cambiar a la escena "Ranking"
        SceneManager.LoadScene("Ranking");
    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        Debug.Log("El nombre '" + playerName + "' se ha guardado correctamente."); // Mensaje de depuración
    }

    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "Player"); // "Player" es un nombre predeterminado si no se ha guardado uno
    }
}
