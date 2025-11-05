using UnityEngine;
using UnityEngine.SceneManagement;

// 🛑 CLASE ESTÁTICA PARA GUARDAR DATOS GLOBALES
// (Asegúrate de que esta clase esté fuera de la clase GameFlowManager)
public static class GameState
{
    // ID del Personaje: 0 = Pacheco (por defecto)
    public static int SelectedCharacterID = 0; 
    
    // ID del Coche: 0 = Kart de Pacheco (se definirá en la siguiente escena)
    public static int SelectedKartID = 0; 
}


public class GameFlowManager : MonoBehaviour
{
    // ... Puedes eliminar la variable 'private int selectedCharacterID = 0;'
    
    // Función llamada por el botón "SELECCIONAR" en la escena 02
    public void ConfirmSelectionAndLoadNext(int nextSceneIndex)
    {
        // 🛑 PASO CLAVE: La selección de Pacheco ya se guarda como 0 en GameState
        // (Si tuvieras la lógica de alternar, aquí se actualizaría GameState.SelectedCharacterID)
        
        Debug.Log("Personaje seleccionado (ID): " + GameState.SelectedCharacterID);

        // Carga la siguiente escena (Selección de Coche, índice 2)
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Función para la transición inicial del menú principal (PLAY) y ATRA
    public void LoadSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}