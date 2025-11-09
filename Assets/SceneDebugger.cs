using UnityEngine;

public class SceneDebugger : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== DEBUGGING ESCENA ===");
        
        // Buscar todos los objetos con "pacheco" en el nombre
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        
        Debug.Log("Objetos encontrados:");
        foreach (GameObject obj in allObjects)
        {
            if (obj.name.ToLower().Contains("pacheco") || obj.name.ToLower().Contains("coche") || obj.name.ToLower().Contains("kart"))
            {
                Debug.Log($"- {obj.name} (Activo: {obj.activeInHierarchy})");
            }
        }
        
        // Verificar Audio Listeners
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        Debug.Log($"Audio Listeners encontrados: {listeners.Length}");
        foreach (AudioListener listener in listeners)
        {
            Debug.Log($"- {listener.gameObject.name} (Enabled: {listener.enabled})");
        }
    }
}