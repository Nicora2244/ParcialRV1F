using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValidateCedulaAndLoadScene : MonoBehaviour
{
    public InputField cedulaInputField; // Referencia al campo de entrada de la cédula
    public string nextSceneName; // Nombre de la siguiente escena

    public void CheckCedulaAndLoadScene()
    {
        // Verifica si el número de cédula ingresado es igual a "31285883"
        if (cedulaInputField.text == "31285883")
        {
            SceneManager.LoadScene(nextSceneName); // Cargar la siguiente escena
        }
        else
        {
            Debug.Log("Número de cédula incorrecto. Inténtalo de nuevo."); // Mensaje de error
        }
    }
}
