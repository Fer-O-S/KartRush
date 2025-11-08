using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour
{
    [Header("Configuración de Personajes")]
    public GameObject[] characterModels; // Arreglo de modelos 3D de personajes
    public Button[] characterButtons;    // Botones para cada personaje
    
    [Header("UI Feedback")]
    public GameObject selectionIndicator; // Indicador visual (ej: un marco dorado)
    
    private int currentCharacterIndex = 0; // Índice actual seleccionado

    void Start()
    {
        // Cargar la selección previa si existe
        currentCharacterIndex = GameState.SelectedCharacterID;
        
        // Configurar botones
        SetupCharacterButtons();
        
        // Mostrar personaje inicial
        UpdateCharacterDisplay();
    }

    void SetupCharacterButtons()
    {
        for (int i = 0; i < characterButtons.Length; i++)
        {
            int characterIndex = i; // Captura local para el closure
            characterButtons[i].onClick.AddListener(() => SelectCharacter(characterIndex));
        }
    }

    public void SelectCharacter(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < characterModels.Length)
        {
            currentCharacterIndex = characterIndex;
            GameState.SelectedCharacterID = characterIndex;
            
            UpdateCharacterDisplay();
            
            Debug.Log($"Personaje seleccionado: {characterIndex}");
        }
    }

    void UpdateCharacterDisplay()
    {
        // Ocultar todos los personajes
        for (int i = 0; i < characterModels.Length; i++)
        {
            characterModels[i].SetActive(i == currentCharacterIndex);
        }
        
        // Actualizar indicador visual si existe
        if (selectionIndicator != null && characterButtons.Length > 0)
        {
            Vector3 buttonPos = characterButtons[currentCharacterIndex].transform.position;
            selectionIndicator.transform.position = buttonPos;
        }
        
        // Actualizar estado de botones
        for (int i = 0; i < characterButtons.Length; i++)
        {
            // Cambiar color o estado del botón seleccionado
            ColorBlock colors = characterButtons[i].colors;
            colors.normalColor = (i == currentCharacterIndex) ? Color.green : Color.white;
            characterButtons[i].colors = colors;
        }
    }

    // Función para navegar con flechas (opcional)
    public void NextCharacter()
    {
        int nextIndex = (currentCharacterIndex + 1) % characterModels.Length;
        SelectCharacter(nextIndex);
    }

    public void PreviousCharacter()
    {
        int prevIndex = (currentCharacterIndex - 1 + characterModels.Length) % characterModels.Length;
        SelectCharacter(prevIndex);
    }
}