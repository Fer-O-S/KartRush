using UnityEngine;

public class FindPachecos : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== BUSCANDO TODOS LOS PACHECOS ===");
        
        // Buscar todos los GameObjects en la escena
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        
        foreach (GameObject obj in allObjects)
        {
            string name = obj.name.ToLower();
            if (name.Contains("pacheco"))
            {
                Debug.Log($"📋 ENCONTRADO: {obj.name}");
                Debug.Log($"   - Activo en jerarquía: {obj.activeInHierarchy}");
                Debug.Log($"   - Activo en escena: {obj.activeSelf}");
                Debug.Log($"   - Posición: {obj.transform.position}");
                Debug.Log($"   - Padre: {(obj.transform.parent ? obj.transform.parent.name : "Ninguno")}");
                Debug.Log("   ---");
            }
        }
        
        // También buscar por otros nombres posibles
        string[] posibleNames = {"blanco", "white", "pose", "character", "personaje"};
        
        Debug.Log("=== BUSCANDO OTROS OBJETOS RELACIONADOS ===");
        foreach (GameObject obj in allObjects)
        {
            string name = obj.name.ToLower();
            foreach (string search in posibleNames)
            {
                if (name.Contains(search) && !name.Contains("camera") && !name.Contains("light"))
                {
                    Debug.Log($"🔍 POSIBLE: {obj.name} (Activo: {obj.activeInHierarchy})");
                    break;
                }
            }
        }
    }
}