using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableCharacterUI : MonoBehaviour, IPointerClickHandler
{
    [Header("Configuración del Personaje")]
    public int characterID;  // 0 = Colorido, 1 = Blanco
    public string characterName = "Personaje";
    
    [Header("Efectos Visuales (Opcional)")]
    public GameObject selectionIndicator;
    
    private bool isSelected = false;
    private CharacterClickManager manager;
    private Image imageComponent;

    void Start()
    {
        // Buscar el manager
        manager = FindObjectOfType<CharacterClickManager>();
        
        // Obtener el componente Image para efectos visuales
        imageComponent = GetComponent<Image>();
        
        Debug.Log($"🎮 Personaje UI clickeable configurado: {characterName} (ID: {characterID})");
    }

    // Esta función se llama automáticamente cuando haces clic en el elemento UI
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectThisCharacter();
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
        
        // Cambiar opacidad o color de la imagen
        if (imageComponent != null)
        {
            Color color = imageComponent.color;
            color.a = selected ? 1f : 0.7f; // Más opaco si está seleccionado
            imageComponent.color = color;
        }
        
        // Para RawImage
        var rawImage = GetComponent<RawImage>();
        if (rawImage != null)
        {
            Color color = rawImage.color;
            color.a = selected ? 1f : 0.7f; // Más opaco si está seleccionado
            rawImage.color = color;
        }
        
        Debug.Log($"📝 {characterName} selección UI: {(selected ? "SELECCIONADO" : "NO SELECCIONADO")}");
    }
}