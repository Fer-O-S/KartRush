using UnityEngine;

public class CharacterSetupHelper : MonoBehaviour
{
    [Header("Configuración Automática")]
    [SerializeField] private bool autoSetup = true;
    
    [Header("Referencias Encontradas")]
    public GameObject pachecoColoridoFound;
    public GameObject pachecoBlancoFound;
    
    void Start()
    {
        if (autoSetup)
        {
            SetupCharacters();
        }
    }
    
    [ContextMenu("Buscar y Configurar Personajes")]
    public void SetupCharacters()
    {
        Debug.Log("🔧 Configurando personajes automáticamente...");
        
        // Buscar todos los objetos de tipo GameObject
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        
        foreach (GameObject obj in allObjects)
        {
            // Buscar el Pacheco colorido (debería estar en PachecoDisplay)
            if (obj.name == "PachecoDisplay")
            {
                pachecoColoridoFound = obj;
                Debug.Log($"✅ Pacheco Colorido encontrado: {obj.name}");
            }
            
            // Buscar el Pacheco blanco
            if (obj.name == "pacheco pose T (1)" || obj.name == "pacheco pose T" && obj.activeInHierarchy)
            {
                pachecoBlancoFound = obj;
                Debug.Log($"✅ Pacheco Blanco encontrado: {obj.name}");
            }
        }
        
        // Asignar automáticamente al CharacterSelector si existe
        SimpleCharacterSelector selector = FindObjectOfType<SimpleCharacterSelector>();
        if (selector != null)
        {
            if (pachecoColoridoFound != null)
            {
                // Usar reflexión para asignar el campo privado
                var field1 = typeof(SimpleCharacterSelector).GetField("pachecoColorido", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (field1 != null)
                    field1.SetValue(selector, pachecoColoridoFound);
            }
            
            if (pachecoBlancoFound != null)
            {
                var field2 = typeof(SimpleCharacterSelector).GetField("pachecoBlanco", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (field2 != null)
                    field2.SetValue(selector, pachecoBlancoFound);
            }
            
            Debug.Log("🎯 Referencias asignadas al CharacterSelector");
        }
    }
}