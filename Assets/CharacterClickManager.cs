using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterClickManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI selectedCharacterText;  // Texto que muestra "Personaje seleccionado: ..."
    public Text selectedCharacterTextLegacy;       // Para texto UI legacy (opcional)
    public Button selectButton;                    // Botón "SELECCIONAR"
    
    [Header("Visual Feedback")]
    public GameObject[] characterHighlights; // Objetos que aparecen sobre el personaje seleccionado
    
    [Header("Audio (Opcional)")]
    public AudioSource clickSound;
    
    private int currentSelectedID = 0;
    private string currentSelectedName = "Pacheco Colorido";
    private ClickableCharacter[] allCharacters;
    private ClickableCharacterUI[] allCharactersUI;

    void Start()
    {
        Debug.Log("🎮 Iniciando CharacterClickManager...");
        
        // Encontrar todos los personajes clickeables (3D y UI)
        allCharacters = FindObjectsOfType<ClickableCharacter>();
        allCharactersUI = FindObjectsOfType<ClickableCharacterUI>();
        Debug.Log($"📋 Encontrados {allCharacters.Length} personajes 3D y {allCharactersUI.Length} personajes UI clickeables");
        
        // Configurar el botón seleccionar
        if (selectButton != null)
        {
            selectButton.onClick.AddListener(ConfirmSelection);
        }
        
        // Seleccionar el personaje inicial
        SelectCharacter(GameState.SelectedCharacterID, GetCharacterName(GameState.SelectedCharacterID));
    }

    public void SelectCharacter(int characterID, string characterName)
    {
        Debug.Log($"🎯 Seleccionando personaje: {characterName} (ID: {characterID})");
        
        currentSelectedID = characterID;
        currentSelectedName = characterName;
        
        // Guardar en el estado global inmediatamente
        GameState.SelectedCharacterID = characterID;
        
        // Actualizar visual de todos los personajes
        UpdateCharacterVisuals();
        
        // Actualizar UI
        UpdateUI();
        
        // Reproducir sonido si está configurado
        if (clickSound != null)
        {
            clickSound.Play();
        }
    }
    
    void UpdateCharacterVisuals()
    {
        // Actualizar estado visual de todos los personajes 3D
        foreach (ClickableCharacter character in allCharacters)
        {
            bool isSelected = (character.characterID == currentSelectedID);
            character.SetSelected(isSelected);
        }
        
        // Actualizar estado visual de todos los personajes UI
        foreach (ClickableCharacterUI characterUI in allCharactersUI)
        {
            bool isSelected = (characterUI.characterID == currentSelectedID);
            characterUI.SetSelected(isSelected);
        }
        
        // Actualizar highlights globales si existen
        for (int i = 0; i < characterHighlights.Length; i++)
        {
            if (characterHighlights[i] != null)
            {
                characterHighlights[i].SetActive(i == currentSelectedID);
            }
        }
    }
    
    void UpdateUI()
    {
        // Actualizar texto (funciona con TextMeshPro y Text legacy)
        string textToShow = $"Seleccionado: {currentSelectedName}";
        
        if (selectedCharacterText != null)
        {
            selectedCharacterText.text = textToShow;
        }
        
        if (selectedCharacterTextLegacy != null)
        {
            selectedCharacterTextLegacy.text = textToShow;
        }
        
        Debug.Log($"📱 UI actualizada - Personaje: {currentSelectedName} (ID: {currentSelectedID})");
    }
    
    public void ConfirmSelection()
    {
        Debug.Log($"✅ Confirmando selección: {currentSelectedName} (ID: {currentSelectedID})");
        
        // Usar el GameFlowManager existente para ir a la siguiente escena
        GameFlowManager gameFlow = FindObjectOfType<GameFlowManager>();
        if (gameFlow != null)
        {
            gameFlow.ConfirmCharacterSelectionAndLoadNext();
        }
        else
        {
            Debug.LogWarning("⚠️ GameFlowManager no encontrado. Cargando escena manualmente...");
            UnityEngine.SceneManagement.SceneManager.LoadScene(2); // Escena de selección de carros
        }
    }
    
    // Función auxiliar para obtener nombres
    string GetCharacterName(int id)
    {
        switch (id)
        {
            case 0: return "Pacheco Colorido";
            case 1: return "Pacheco Blanco";
            default: return $"Personaje {id}";
        }
    }
    
    // Funciones públicas para botones adicionales (opcional)
    public void SelectPachecoColorido()
    {
        SelectCharacter(0, "Pacheco Colorido");
    }
    
    public void SelectPachecoBlanco()
    {
        SelectCharacter(1, "Pacheco Blanco");
    }
    
    // Función de debug
    [ContextMenu("Mostrar Estado Actual")]
    public void ShowCurrentState()
    {
        Debug.Log($"📋 ESTADO ACTUAL:");
        Debug.Log($"   Personaje seleccionado: {currentSelectedName} (ID: {currentSelectedID})");
        Debug.Log($"   GameState.SelectedCharacterID: {GameState.SelectedCharacterID}");
    }
}