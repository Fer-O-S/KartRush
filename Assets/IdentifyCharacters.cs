using UnityEngine;

public class IdentifyCharacters : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== IDENTIFICANDO PERSONAJES ===");
        
        // Buscar los dos modelos de Pacheco
        GameObject pachecoT = GameObject.Find("pacheco pose T");
        GameObject pachecoT1 = GameObject.Find("pacheco pose T (1)");
        
        if (pachecoT != null)
        {
            Debug.Log($"📋 pacheco pose T:");
            Debug.Log($"   - Posición: {pachecoT.transform.position}");
            Debug.Log($"   - Activo: {pachecoT.activeInHierarchy}");
            
            // Verificar si tiene materiales diferentes
            var renderer = pachecoT.GetComponentInChildren<Renderer>();
            if (renderer != null && renderer.material != null)
            {
                Debug.Log($"   - Material: {renderer.material.name}");
                Debug.Log($"   - Color principal: {renderer.material.color}");
            }
        }
        
        if (pachecoT1 != null)
        {
            Debug.Log($"📋 pacheco pose T (1):");
            Debug.Log($"   - Posición: {pachecoT1.transform.position}");
            Debug.Log($"   - Activo: {pachecoT1.activeInHierarchy}");
            
            // Verificar si tiene materiales diferentes
            var renderer = pachecoT1.GetComponentInChildren<Renderer>();
            if (renderer != null && renderer.material != null)
            {
                Debug.Log($"   - Material: {renderer.material.name}");
                Debug.Log($"   - Color principal: {renderer.material.color}");
            }
        }
        
        // También verificar los display UI
        GameObject displayColorido = GameObject.Find("PachecoDisplay");
        GameObject displayBlanco = GameObject.Find("PachecoBlancoDisplay");
        
        if (displayColorido != null)
            Debug.Log($"📱 PachecoDisplay activo: {displayColorido.activeInHierarchy}");
            
        if (displayBlanco != null)
            Debug.Log($"📱 PachecoBlancoDisplay activo: {displayBlanco.activeInHierarchy}");
    }
    
    [ContextMenu("Activar Ambos Modelos")]
    public void ActivarAmbosModelos()
    {
        GameObject pachecoT = GameObject.Find("pacheco pose T");
        GameObject pachecoT1 = GameObject.Find("pacheco pose T (1)");
        
        if (pachecoT != null)
        {
            pachecoT.SetActive(true);
            Debug.Log("✅ pacheco pose T activado");
        }
        
        if (pachecoT1 != null)
        {
            pachecoT1.SetActive(true);
            Debug.Log("✅ pacheco pose T (1) activado");
        }
    }
}