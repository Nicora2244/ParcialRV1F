using UnityEngine;
using TMPro;

// Asegúrate de incluir el siguiente espacio de nombres donde desees acceder a los métodos de Leaderboard Creator
using Dan.Main;

namespace LeaderboardCreatorDemo
{
    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_InputField _usernameInputField;

        // Define una variable para almacenar la puntuación del jugador
        [SerializeField] private int _playerScore = 0;

        // Utiliza la variable _playerScore en el método Score
        private int Score => _playerScore;

        private void Start()
        {
            LoadEntries();
        }

        private void LoadEntries()
        {
            // Cómo hacer referencia a tu propio marcador de posición?
            // Leaderboards.<NombreDelMarcador>

            Leaderboards.Ranking.GetEntries(entries =>
            {
                foreach (var t in _entryTextObjects)
                    t.text = "";

                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $"{entries[i].Rank}. {entries[i].Username} - {entries[i].Score}";
            });
        }

        public void UploadEntry()
        {
            Leaderboards.Ranking.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }
    }
}
