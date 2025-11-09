using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableKartUI : MonoBehaviour, IPointerClickHandler
{
    [Header("Configuración del Carro")]
    public int kartID;  // 0 = Carro 1, 1 = Carro 2, etc.
    public string kartName = "Carro";
    
    [Header("Información del Carro (Opcional)")]
    [TextArea(3,5)]
    public string kartDescription = "Descripción del carro";
    public int speed = 5;
    public int acceleration = 5; 
    public int handling = 5;
    
    [Header("Efectos Visuales (Opcional)")]
    public GameObject selectionIndicator;
    
    private bool isSelected = false;
    private KartClickManager manager;

    void Start()
    {
        // Buscar el manager
        manager = FindObjectOfType<KartClickManager>();
        
        Debug.Log($"🏎️ Carro UI clickeable configurado: {kartName} (ID: {kartID})");
    }

    // Esta función se llama automáticamente cuando haces clic en el elemento UI
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectThisKart();
    }

    public void SelectThisKart()
    {
        if (manager != null)
        {
            manager.SelectKart(kartID, kartName, kartDescription, speed, acceleration, handling);
        }
        
        Debug.Log($"🎯 ¡Seleccionaste {kartName}! (ID: {kartID})");
    }
    
    public void SetSelected(bool selected)
    {
        isSelected = selected;
        
        // Activar/desactivar indicador visual
        if (selectionIndicator != null)
        {
            selectionIndicator.SetActive(selected);
        }
        
        // Cambiar opacidad de la imagen
        var rawImage = GetComponent<RawImage>();
        if (rawImage != null)
        {
            Color color = rawImage.color;
            color.a = selected ? 1f : 0.7f; // Más opaco si está seleccionado
            rawImage.color = color;
        }
        
        // También para Image normal
        var image = GetComponent<Image>();
        if (image != null)
        {
            Color color = image.color;
            color.a = selected ? 1f : 0.7f;
            image.color = color;
        }
        
        Debug.Log($"📝 {kartName} selección UI: {(selected ? "SELECCIONADO" : "NO SELECCIONADO")}");
    }
}