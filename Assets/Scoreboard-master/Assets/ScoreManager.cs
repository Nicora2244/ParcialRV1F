using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    private ScoreData sd;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        var json = PlayerPrefs.GetString("scores", "{}");
        sd = JsonUtility.FromJson<ScoreData>(json);
    }

    public IEnumerable<Score> GetHighScores()
    {
        return sd.scores.OrderByDescending(x => x.score);
    }

    public void AddScore(Score score)
    {
        sd.scores.Add(score);
        SaveScore();
    }

    private void OnDestroy()
    {
        SaveScore();
    }

    public void SaveScore()
    {
        var json = JsonUtility.ToJson(sd);
        PlayerPrefs.SetString("scores", json);
    }

    // Nuevo método para guardar y recuperar el nombre del jugador
    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "Player"); // "Player" es un nombre predeterminado si no se ha guardado uno
    }
}
