using UnityEngine;
using UnityEngine.UI;

public class KartSelector : MonoBehaviour
{
    [Header("Configuración de Carros")]
    public GameObject[] kartModels;   // Arreglo de modelos 3D de carros
    public Button[] kartButtons;      // Botones para cada carro
    
    [Header("UI Feedback")]
    public GameObject selectionIndicator; // Indicador visual
    public Text kartNameText;             // Texto para mostrar nombre del carro
    public Text kartStatsText;            // Texto para mostrar estadísticas
    
    [Header("Información de Carros")]
    public KartInfo[] kartInfos;          // Información de cada carro
    
    private int currentKartIndex = 0;

    void Start()
    {
        // Cargar la selección previa si existe
        currentKartIndex = GameState.SelectedKartID;
        
        // Configurar botones
        SetupKartButtons();
        
        // Mostrar carro inicial
        UpdateKartDisplay();
    }

    void SetupKartButtons()
    {
        for (int i = 0; i < kartButtons.Length; i++)
        {
            int kartIndex = i; // Captura local para el closure
            kartButtons[i].onClick.AddListener(() => SelectKart(kartIndex));
        }
    }

    public void SelectKart(int kartIndex)
    {
        if (kartIndex >= 0 && kartIndex < kartModels.Length)
        {
            currentKartIndex = kartIndex;
            GameState.SelectedKartID = kartIndex;
            
            UpdateKartDisplay();
            
            Debug.Log($"Carro seleccionado: {kartIndex}");
        }
    }

    void UpdateKartDisplay()
    {
        // Ocultar todos los carros
        for (int i = 0; i < kartModels.Length; i++)
        {
            kartModels[i].SetActive(i == currentKartIndex);
        }
        
        // Actualizar indicador visual
        if (selectionIndicator != null && kartButtons.Length > 0)
        {
            Vector3 buttonPos = kartButtons[currentKartIndex].transform.position;
            selectionIndicator.transform.position = buttonPos;
        }
        
        // Actualizar información del carro
        if (kartInfos != null && currentKartIndex < kartInfos.Length)
        {
            var kartInfo = kartInfos[currentKartIndex];
            
            if (kartNameText != null)
                kartNameText.text = kartInfo.kartName;
                
            if (kartStatsText != null)
                kartStatsText.text = $"Velocidad: {kartInfo.speed}\nAceleración: {kartInfo.acceleration}\nManejo: {kartInfo.handling}";
        }
        
        // Actualizar estado de botones
        for (int i = 0; i < kartButtons.Length; i++)
        {
            ColorBlock colors = kartButtons[i].colors;
            colors.normalColor = (i == currentKartIndex) ? Color.green : Color.white;
            kartButtons[i].colors = colors;
        }
    }

    public void NextKart()
    {
        int nextIndex = (currentKartIndex + 1) % kartModels.Length;
        SelectKart(nextIndex);
    }

    public void PreviousKart()
    {
        int prevIndex = (currentKartIndex - 1 + kartModels.Length) % kartModels.Length;
        SelectKart(prevIndex);
    }
}

[System.Serializable]
public class KartInfo
{
    public string kartName;
    public int speed;
    public int acceleration;
    public int handling;
}