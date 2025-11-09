using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KartClickManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI selectedKartText;           // Texto que muestra "Carro seleccionado: ..."
    public TextMeshProUGUI kartDescriptionText;        // Texto con descripción del carro
    public TextMeshProUGUI kartStatsText;              // Texto con estadísticas del carro
    public Text selectedKartTextLegacy;                // Para texto UI legacy (opcional)
    public Button selectButton;                        // Botón "SELECCIONAR"
    
    [Header("Visual Feedback")]
    public GameObject[] kartHighlights;                // Objetos que aparecen sobre el carro seleccionado
    
    [Header("Audio (Opcional)")]
    public AudioSource clickSound;
    
    private int currentSelectedID = 0;
    private string currentSelectedName = "Carro Rojo/Amarillo";
    private string currentSelectedDescription = "Carro balanceado";
    private ClickableKartUI[] allKarts;

    void Start()
    {
        Debug.Log("🏎️ Iniciando KartClickManager...");
        
        // Encontrar todos los carros clickeables
        allKarts = FindObjectsOfType<ClickableKartUI>();
        Debug.Log($"📋 Encontrados {allKarts.Length} carros UI clickeables");
        
        // Configurar el botón seleccionar
        if (selectButton != null)
        {
            selectButton.onClick.AddListener(ConfirmSelection);
        }
        
        // Seleccionar el carro inicial
        SelectKart(GameState.SelectedKartID, GetKartName(GameState.SelectedKartID), 
                  GetKartDescription(GameState.SelectedKartID), 5, 5, 5);
    }

    public void SelectKart(int kartID, string kartName, string description = "", int speed = 5, int acceleration = 5, int handling = 5)
    {
        Debug.Log($"🎯 Seleccionando carro: {kartName} (ID: {kartID})");
        
        currentSelectedID = kartID;
        currentSelectedName = kartName;
        currentSelectedDescription = description;
        
        // Guardar en el estado global inmediatamente
        GameState.SelectedKartID = kartID;
        
        // Actualizar visual de todos los carros
        UpdateKartVisuals();
        
        // Actualizar UI
        UpdateUI(speed, acceleration, handling);
        
        // Reproducir sonido si está configurado
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
    
    void UpdateKartVisuals()
    {
        // Actualizar estado visual de todos los carros UI
        foreach (ClickableKartUI kart in allKarts)
        {
            bool isSelected = (kart.kartID == currentSelectedID);
            kart.SetSelected(isSelected);
        }
        
        // Actualizar highlights globales si existen
        for (int i = 0; i < kartHighlights.Length; i++)
        {
            if (kartHighlights[i] != null)
            {
                kartHighlights[i].SetActive(i == currentSelectedID);
            }
        }
    }
    
    void UpdateUI(int speed, int acceleration, int handling)
    {
        // Actualizar texto principal
        string mainText = $"Seleccionado: {currentSelectedName}";
        
        if (selectedKartText != null)
        {
            selectedKartText.text = mainText;
        }
        
        if (selectedKartTextLegacy != null)
        {
            selectedKartTextLegacy.text = mainText;
        }
        
        // Actualizar descripción
        if (kartDescriptionText != null && !string.IsNullOrEmpty(currentSelectedDescription))
        {
            kartDescriptionText.text = currentSelectedDescription;
        }
        
        // Actualizar estadísticas
        if (kartStatsText != null)
        {
            string stats = $"Velocidad: {GetStarRating(speed)}\n";
            stats += $"Aceleración: {GetStarRating(acceleration)}\n";
            stats += $"Manejo: {GetStarRating(handling)}";
            kartStatsText.text = stats;
        }
        
        Debug.Log($"📱 UI actualizada - Carro: {currentSelectedName} (ID: {currentSelectedID})");
    }
    
    string GetStarRating(int rating)
    {
        string stars = "";
        for (int i = 1; i <= 5; i++)
        {
            stars += (i <= rating) ? "★" : "☆";
        }
        return stars;
    }
    
    public void ConfirmSelection()
    {
        Debug.Log($"✅ Confirmando selección de carro: {currentSelectedName} (ID: {currentSelectedID})");
        
        // Usar el GameFlowManager existente para ir a la siguiente escena
        GameFlowManager gameFlow = FindObjectOfType<GameFlowManager>();
        if (gameFlow != null)
        {
            gameFlow.ConfirmKartSelectionAndLoadNext();
        }
        else
        {
            Debug.LogWarning("⚠️ GameFlowManager no encontrado. Cargando escena manualmente...");
            UnityEngine.SceneManagement.SceneManager.LoadScene(3); // Escena de selección de pista
        }
    }
    
    // Funciones auxiliares para obtener nombres y descripciones
    string GetKartName(int id)
    {
        switch (id)
        {
            case 0: return "Carro Rápido";
            case 1: return "Carro Resistente";
            default: return $"Carro {id}";
        }
    }
    
    string GetKartDescription(int id)
    {
        switch (id)
        {
            case 0: return "Alto rendimiento y velocidad máxima. Ideal para circuitos rectos.";
            case 1: return "Excelente manejo y resistencia. Perfecto para curvas cerradas.";
            default: return "Descripción del carro.";
        }
    }
    
    // Funciones públicas para botones adicionales (opcional)
    public void SelectKart1()
    {
        SelectKart(0, "Carro Rápido", GetKartDescription(0), 5, 4, 3);
    }
    
    public void SelectKart2()
    {
        SelectKart(1, "Carro Resistente", GetKartDescription(1), 3, 4, 5);
    }
    
    // Función de debug
    [ContextMenu("Mostrar Estado Actual")]
    public void ShowCurrentState()
    {
        Debug.Log($"📋 ESTADO ACTUAL:");
        Debug.Log($"   Carro seleccionado: {currentSelectedName} (ID: {currentSelectedID})");
        Debug.Log($"   GameState.SelectedKartID: {GameState.SelectedKartID}");
    }
}