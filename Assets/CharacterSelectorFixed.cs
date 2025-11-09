using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectorFixed : MonoBehaviour
{
    [Header("Modelos 3D de Personajes (NO las imágenes UI)")]
    public GameObject modeloPachecoColorido;   // Arrastra "pacheco pose T" aquí
    public GameObject modeloPachecoBlanco;     // Arrastra "pacheco pose T (1)" aquí
    
    [Header("Botones de Selección")]
    public Button botonPachecoColorido;  
    public Button botonPachecoBlanco;    
    
    [Header("Imágenes UI (Opcional - para highlights)")]
    public GameObject imagenPachecoColorido; // PachecoDisplay (opcional)
    public GameObject imagenPachecoBlanco;   // PachecoBlancoDisplay (opcional)
    
    [Header("Indicador Visual (Opcional)")]
    public GameObject indicadorSeleccion;
    
    private int personajeSeleccionado = 0;

    void Start()
    {
        Debug.Log("🎮 Iniciando CharacterSelectorFixed...");
        
        // Auto-buscar modelos si no están asignados
        if (modeloPachecoColorido == null)
        {
            modeloPachecoColorido = GameObject.Find("pacheco pose T");
            if (modeloPachecoColorido != null)
                Debug.Log("🔍 Auto-encontrado Pacheco Colorido: pacheco pose T");
        }
        
        if (modeloPachecoBlanco == null)
        {
            modeloPachecoBlanco = GameObject.Find("pacheco pose T (1)");
            if (modeloPachecoBlanco != null)
                Debug.Log("🔍 Auto-encontrado Pacheco Blanco: pacheco pose T (1)");
        }
        
        // Verificar que los MODELOS 3D estén asignados
        if (modeloPachecoColorido == null)
            Debug.LogError("❌ MODELO Pacheco Colorido no encontrado! Debe llamarse 'pacheco pose T'");
        if (modeloPachecoBlanco == null)
            Debug.LogError("❌ MODELO Pacheco Blanco no encontrado! Debe llamarse 'pacheco pose T (1)'");
        
        // Configurar los botones
        if (botonPachecoColorido != null)
        {
            botonPachecoColorido.onClick.AddListener(() => SeleccionarPersonaje(0));
            Debug.Log("✅ Botón Pacheco Colorido configurado");
        }
            
        if (botonPachecoBlanco != null)
        {
            botonPachecoBlanco.onClick.AddListener(() => SeleccionarPersonaje(1));
            Debug.Log("✅ Botón Pacheco Blanco configurado");
        }
        
        // Asegurar que las imágenes UI estén siempre activas
        if (imagenPachecoColorido != null) imagenPachecoColorido.SetActive(true);
        if (imagenPachecoBlanco != null) imagenPachecoBlanco.SetActive(true);
        
        // IMPORTANTE: Asegurar que ambos modelos existan antes de seleccionar
        if (modeloPachecoColorido != null) modeloPachecoColorido.SetActive(false);
        if (modeloPachecoBlanco != null) modeloPachecoBlanco.SetActive(false);
        
        // Esperar un frame antes de seleccionar el inicial
        Invoke("SeleccionarPersonajeInicial", 0.1f);
    }
    
    void SeleccionarPersonajeInicial()
    {
        Debug.Log("🎯 Seleccionando personaje inicial...");
        SeleccionarPersonaje(GameState.SelectedCharacterID);
    }

    public void SeleccionarPersonaje(int idPersonaje)
    {
        Debug.Log($"🎯 Seleccionando personaje ID: {idPersonaje}");
        
        personajeSeleccionado = idPersonaje;
        GameState.SelectedCharacterID = idPersonaje;
        
        // Controlar SOLO los modelos 3D, NO las imágenes UI
        if (modeloPachecoColorido != null)
        {
            bool activarColorido = (idPersonaje == 0);
            modeloPachecoColorido.SetActive(activarColorido);
            Debug.Log($"Modelo Pacheco Colorido: {(activarColorido ? "ACTIVO" : "INACTIVO")}");
        }
            
        if (modeloPachecoBlanco != null)
        {
            bool activarBlanco = (idPersonaje == 1);
            modeloPachecoBlanco.SetActive(activarBlanco);
            Debug.Log($"Modelo Pacheco Blanco: {(activarBlanco ? "ACTIVO" : "INACTIVO")}");
        }
        
        // Opcional: Destacar la imagen UI correspondiente
        DestacarImagenUI(idPersonaje);
        
        // Mover indicador visual (si existe)
        MoverIndicadorSeleccion(idPersonaje);
        
        // Actualizar colores de botones
        ActualizarColoresBotones(idPersonaje);
        
        Debug.Log($"✅ Personaje seleccionado: {(idPersonaje == 0 ? "Pacheco Colorido" : "Pacheco Blanco")} (ID: {idPersonaje})");
    }
    
    void DestacarImagenUI(int idPersonaje)
    {
        // Opcional: Cambiar opacidad o color de las imágenes UI para mostrar selección
        if (imagenPachecoColorido != null)
        {
            var rawImage = imagenPachecoColorido.GetComponent<RawImage>();
            if (rawImage != null)
            {
                Color color = rawImage.color;
                color.a = (idPersonaje == 0) ? 1f : 0.5f; // Más opaco si está seleccionado
                rawImage.color = color;
            }
        }
        
        if (imagenPachecoBlanco != null)
        {
            var rawImage = imagenPachecoBlanco.GetComponent<RawImage>();
            if (rawImage != null)
            {
                Color color = rawImage.color;
                color.a = (idPersonaje == 1) ? 1f : 0.5f; // Más opaco si está seleccionado
                rawImage.color = color;
            }
        }
    }
    
    void MoverIndicadorSeleccion(int idPersonaje)
    {
        if (indicadorSeleccion == null) return;
        
        if (idPersonaje == 0 && botonPachecoColorido != null)
        {
            indicadorSeleccion.transform.position = botonPachecoColorido.transform.position;
        }
        else if (idPersonaje == 1 && botonPachecoBlanco != null)
        {
            indicadorSeleccion.transform.position = botonPachecoBlanco.transform.position;
        }
    }
    
    void ActualizarColoresBotones(int idPersonaje)
    {
        if (botonPachecoColorido != null)
        {
            ColorBlock colores = botonPachecoColorido.colors;
            colores.normalColor = (idPersonaje == 0) ? Color.green : Color.white;
            botonPachecoColorido.colors = colores;
        }
        
        if (botonPachecoBlanco != null)
        {
            ColorBlock colores = botonPachecoBlanco.colors;
            colores.normalColor = (idPersonaje == 1) ? Color.green : Color.white;
            botonPachecoBlanco.colors = colores;
        }
    }
    
    public void SiguientePersonaje()
    {
        int siguiente = (personajeSeleccionado + 1) % 2;
        SeleccionarPersonaje(siguiente);
    }
    
    public void AnteriorPersonaje()
    {
        int anterior = (personajeSeleccionado - 1 + 2) % 2;
        SeleccionarPersonaje(anterior);
    }
    
    // Función de testing - la puedes llamar desde el Inspector
    [ContextMenu("Mostrar Pacheco Blanco")]
    public void TestMostrarPachecoBlanco()
    {
        Debug.Log("🧪 TESTING: Activando Pacheco Blanco...");
        if (modeloPachecoBlanco != null)
        {
            modeloPachecoBlanco.SetActive(true);
            Debug.Log("✅ Pacheco Blanco activado manualmente");
        }
        else
        {
            Debug.LogError("❌ modeloPachecoBlanco es NULL!");
        }
        
        if (modeloPachecoColorido != null)
        {
            modeloPachecoColorido.SetActive(false);
            Debug.Log("⚪ Pacheco Colorido desactivado");
        }
    }
    
    [ContextMenu("Mostrar Ambos Personajes")]
    public void TestMostrarAmbos()
    {
        Debug.Log("🧪 TESTING: Activando ambos personajes...");
        if (modeloPachecoColorido != null) modeloPachecoColorido.SetActive(true);
        if (modeloPachecoBlanco != null) modeloPachecoBlanco.SetActive(true);
    }
}