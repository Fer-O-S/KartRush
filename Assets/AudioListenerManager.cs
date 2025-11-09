using UnityEngine;

public class AudioListenerManager : MonoBehaviour
{
    [Header("Configuración")]
    public bool keepThisListener = true; // Marcar cuál listener mantener activo
    
    void Start()
    {
        ManageAudioListeners();
    }
    
    void ManageAudioListeners()
    {
        // Encontrar todos los Audio Listeners en la escena
        AudioListener[] allListeners = FindObjectsOfType<AudioListener>();
        
        if (allListeners.Length > 1)
        {
            Debug.Log($"🔊 Encontrados {allListeners.Length} Audio Listeners. Desactivando extras...");
            
            // Desactivar todos excepto el primero (o el marcado como principal)
            for (int i = 0; i < allListeners.Length; i++)
            {
                if (i == 0 && keepThisListener)
                {
                    // Mantener el primer listener activo
                    allListeners[i].enabled = true;
                    Debug.Log($"✅ Audio Listener mantenido activo: {allListeners[i].gameObject.name}");
                }
                else if (allListeners[i].gameObject == this.gameObject && keepThisListener)
                {
                    // Si este GameObject tiene el listener principal, mantenerlo
                    allListeners[i].enabled = true;
                    Debug.Log($"✅ Audio Listener principal activo: {allListeners[i].gameObject.name}");
                }
                else
                {
                    // Desactivar listeners extras
                    allListeners[i].enabled = false;
                    Debug.Log($"❌ Audio Listener desactivado: {allListeners[i].gameObject.name}");
                }
            }
        }
        else
        {
            Debug.Log("✅ Solo hay un Audio Listener activo.");
        }
    }
    
    // Función para llamar manualmente si es necesario
    public void RefreshAudioListeners()
    {
        ManageAudioListeners();
    }
}