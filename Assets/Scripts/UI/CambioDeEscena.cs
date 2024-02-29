using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public string nombreDeLaEscenaACargar;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Ejemplo: Cambiar de escena cuando se presiona la tecla Espacio
        {
            SceneManager.LoadScene(nombreDeLaEscenaACargar);
        }
    }
}
