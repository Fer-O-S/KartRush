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
    [Header("Debug Info")]
    public bool showDebugInfo = true;
    
    void Start()
    {
        if (showDebugInfo)
        {
            Debug.Log($"Escena actual: {SceneManager.GetActiveScene().name}");
            Debug.Log($"Personaje seleccionado: {GameState.SelectedCharacterID}");
            Debug.Log($"Carro seleccionado: {GameState.SelectedKartID}");
        }
    }
    
    // Función llamada por el botón "SELECCIONAR" en la escena de personajes
    public void ConfirmCharacterSelectionAndLoadNext()
    {
        Debug.Log($"✅ Confirmando selección de personaje (ID): {GameState.SelectedCharacterID}");
        LoadSceneByIndex(2); // Ir a selección de carros
    }
    
    // Función llamada por el botón "SELECCIONAR" en la escena de carros
    public void ConfirmKartSelectionAndLoadNext()
    {
        Debug.Log($"✅ Confirmando selección de carro (ID): {GameState.SelectedKartID}");
        LoadSceneByIndex(3); // Ir a selección de pista
    }
    
    // Función genérica para cargar escenas
    public void LoadSceneByIndex(int sceneIndex)
    {
        if (showDebugInfo)
        {
            Debug.Log($"🔄 Cargando escena con índice: {sceneIndex}");
        }
        SceneManager.LoadScene(sceneIndex);
    }
    
    // Función para cargar escena por nombre (alternativa)
    public void LoadSceneByName(string sceneName)
    {
        if (showDebugInfo)
        {
            Debug.Log($"🔄 Cargando escena: {sceneName}");
        }
        SceneManager.LoadScene(sceneName);
    }
    
    // Función para reiniciar las selecciones
    public void ResetSelections()
    {
        GameState.SelectedCharacterID = 0;
        GameState.SelectedKartID = 0;
        Debug.Log("🔄 Selecciones reiniciadas");
    }
    
    // Función para mostrar selecciones actuales (útil para debug)
    public void ShowCurrentSelections()
    {
        Debug.Log($"📋 SELECCIONES ACTUALES:");
        Debug.Log($"   Personaje: {GameState.SelectedCharacterID}");
        Debug.Log($"   Carro: {GameState.SelectedKartID}");
    }
}