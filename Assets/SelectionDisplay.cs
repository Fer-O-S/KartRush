using UnityEngine;
using UnityEngine.UI;

public class SelectionDisplay : MonoBehaviour
{
    [Header("UI Elements")]
    public Text selectedCharacterText;
    public Text selectedKartText;
    public GameObject selectedCharacterModel;
    public GameObject selectedKartModel;
    
    [Header("Character Models")]
    public GameObject[] characterPrefabs; // Prefabs de personajes
    
    [Header("Kart Models")]
    public GameObject[] kartPrefabs; // Prefabs de carros
    
    [Header("Character Names")]
    public string[] characterNames = { "Pacheco", "Personaje 2", "Personaje 3" };
    
    [Header("Kart Names")]
    public string[] kartNames = { "Kart Básico", "Kart Rápido", "Kart Resistente" };

    void Start()
    {
        UpdateSelectionDisplay();
    }

    void OnEnable()
    {
        // Actualizar cuando se active el objeto
        UpdateSelectionDisplay();
    }

    public void UpdateSelectionDisplay()
    {
        // Actualizar texto de personaje seleccionado
        if (selectedCharacterText != null)
        {
            string characterName = GetCharacterName(GameState.SelectedCharacterID);
            selectedCharacterText.text = $"Personaje: {characterName}";
        }

        // Actualizar texto de carro seleccionado
        if (selectedKartText != null)
        {
            string kartName = GetKartName(GameState.SelectedKartID);
            selectedKartText.text = $"Carro: {kartName}";
        }

        // Mostrar modelo de personaje seleccionado
        ShowSelectedCharacterModel();
        
        // Mostrar modelo de carro seleccionado
        ShowSelectedKartModel();

        Debug.Log($"🎮 CONFIGURACIÓN FINAL:");
        Debug.Log($"   Personaje: {GetCharacterName(GameState.SelectedCharacterID)} (ID: {GameState.SelectedCharacterID})");
        Debug.Log($"   Carro: {GetKartName(GameState.SelectedKartID)} (ID: {GameState.SelectedKartID})");
    }

    void ShowSelectedCharacterModel()
    {
        if (selectedCharacterModel != null && characterPrefabs != null)
        {
            // Destruir modelo anterior si existe
            foreach (Transform child in selectedCharacterModel.transform)
            {
                if (Application.isPlaying)
                    Destroy(child.gameObject);
                else
                    DestroyImmediate(child.gameObject);
            }

            // Instanciar nuevo modelo
            if (GameState.SelectedCharacterID < characterPrefabs.Length && characterPrefabs[GameState.SelectedCharacterID] != null)
            {
                GameObject characterInstance = Instantiate(characterPrefabs[GameState.SelectedCharacterID], selectedCharacterModel.transform);
                characterInstance.transform.localPosition = Vector3.zero;
                characterInstance.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void ShowSelectedKartModel()
    {
        if (selectedKartModel != null && kartPrefabs != null)
        {
            // Destruir modelo anterior si existe
            foreach (Transform child in selectedKartModel.transform)
            {
                if (Application.isPlaying)
                    Destroy(child.gameObject);
                else
                    DestroyImmediate(child.gameObject);
            }

            // Instanciar nuevo modelo
            if (GameState.SelectedKartID < kartPrefabs.Length && kartPrefabs[GameState.SelectedKartID] != null)
            {
                GameObject kartInstance = Instantiate(kartPrefabs[GameState.SelectedKartID], selectedKartModel.transform);
                kartInstance.transform.localPosition = Vector3.zero;
                kartInstance.transform.localRotation = Quaternion.identity;
            }
        }
    }

    string GetCharacterName(int characterID)
    {
        if (characterID >= 0 && characterID < characterNames.Length)
            return characterNames[characterID];
        return $"Personaje {characterID}";
    }

    string GetKartName(int kartID)
    {
        if (kartID >= 0 && kartID < kartNames.Length)
            return kartNames[kartID];
        return $"Carro {kartID}";
    }

    // Función pública para actualizar desde otros scripts
    public void RefreshDisplay()
    {
        UpdateSelectionDisplay();
    }
}