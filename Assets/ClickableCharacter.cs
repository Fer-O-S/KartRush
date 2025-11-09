using UnityEngine;

public class ClickableCharacter : MonoBehaviour
{
    [Header("Configuración del Personaje")]
    public int characterID;  // 0 = Colorido, 1 = Blanco
    public string characterName = "Personaje";
    
    [Header("Efectos Visuales")]
    public GameObject selectionIndicator;  // Opcional: objeto que aparece cuando está seleccionado
    public Material originalMaterial;
    public Material highlightMaterial;     // Opcional: material para destacar cuando está seleccionado
    
    private bool isSelected = false;
    private Renderer characterRenderer;
    private CharacterClickManager manager;

    void Start()
    {
        // Buscar el manager
        manager = FindObjectOfType<CharacterClickManager>();
        
        // Obtener el renderer para cambios visuales
        characterRenderer = GetComponentInChildren<Renderer>();
        if (characterRenderer != null && originalMaterial == null)
        {
            originalMaterial = characterRenderer.material;
        }
        
        Debug.Log($"🎮 Personaje clickeable configurado: {characterName} (ID: {characterID})");
    }

    void OnMouseDown()
    {
        // Detectar clic en el personaje
        SelectThisCharacter();
    }

    void OnMouseOver()
    {
        // Opcional: efecto visual cuando el mouse está encima
        if (!isSelected && highlightMaterial != null && characterRenderer != null)
        {
            // Ligero cambio visual al pasar el mouse
        }
    }

    void OnMouseExit()
    {
        // Restaurar visual si no está seleccionado
        if (!isSelected && originalMaterial != null && characterRenderer != null)
        {
            characterRenderer.material = originalMaterial;
        }
    }

    public void SelectThisCharacter()
    {
        if (manager != null)
        {
            manager.SelectCharacter(characterID, characterName);
        }
        
        Debug.Log($"🎯 ¡Seleccionaste {characterName}! (ID: {characterID})");
    }
    
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        
        // Activar/desactivar indicador visual
        if (selectionIndicator != null)
        {
            selectionIndicator.SetActive(selected);
        }
        
        // Cambiar material si está disponible
        if (characterRenderer != null)
        {
            if (selected && highlightMaterial != null)
            {
                characterRenderer.material = highlightMaterial;
            }
            else if (originalMaterial != null)
            {
                characterRenderer.material = originalMaterial;
            }
        }
        
        Debug.Log($"📝 {characterName} selección: {(selected ? "SELECCIONADO" : "NO SELECCIONADO")}");
    }
}