using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ValidateCedulaAndLoadScene : MonoBehaviour
{
    public InputField cedulaInputField; // Referencia al campo de entrada de la c�dula
    public string nextSceneName; // Nombre de la siguiente escena

    public void CheckCedulaAndLoadScene()
    {
        // Verifica si el n�mero de c�dula ingresado es igual a "31285883"
        if (cedulaInputField.text == "31285883")
        {
            SceneManager.LoadScene(nextSceneName); // Cargar la siguiente escena
        }
        else
        {
            Debug.Log("N�mero de c�dula incorrecto. Int�ntalo de nuevo."); // Mensaje de error
        }
    }
}
