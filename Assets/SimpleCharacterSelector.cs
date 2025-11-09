using UnityEngine;
using UnityEngine.UI;

public class SimpleCharacterSelector : MonoBehaviour
{
    [Header("Modelos de Personajes")]
    public GameObject pachecoColorido;   // Pacheco original (colorido)
    public GameObject pachecoBlanco;     // Pacheco blanco
    
    [Header("Botones de Selección")]
    public Button botonPachecoColorido;  // Botón para seleccionar Pacheco colorido
    public Button botonPachecoBlanco;    // Botón para seleccionar Pacheco blanco
    
    [Header("Indicador Visual (Opcional)")]
    public GameObject indicadorSeleccion; // Marco o indicador que se mueve
    
    private int personajeSeleccionado = 0; // 0 = Pacheco colorido, 1 = Pacheco blanco

    void Start()
    {
        Debug.Log("🎮 Iniciando SimpleCharacterSelector...");
        
        // Verificar que los modelos estén asignados
        if (pachecoColorido == null)
            Debug.LogError("❌ Pacheco Colorido no está asignado en el Inspector!");
        if (pachecoBlanco == null)
            Debug.LogError("❌ Pacheco Blanco no está asignado en el Inspector!");
        
        // Configurar los botones
        if (botonPachecoColorido != null)
        {
            botonPachecoColorido.onClick.AddListener(() => SeleccionarPersonaje(0));
            Debug.Log("✅ Botón Pacheco Colorido configurado");
        }
        else
        {
            Debug.LogWarning("⚠️ Botón Pacheco Colorido no está asignado");
        }
            
        if (botonPachecoBlanco != null)
        {
            botonPachecoBlanco.onClick.AddListener(() => SeleccionarPersonaje(1));
            Debug.Log("✅ Botón Pacheco Blanco configurado");
        }
        else
        {
            Debug.LogWarning("⚠️ Botón Pacheco Blanco no está asignado");
        }
        
        // Mostrar personaje inicial
        SeleccionarPersonaje(GameState.SelectedCharacterID);
    }

    public void SeleccionarPersonaje(int idPersonaje)
    {
        Debug.Log($"🎯 Seleccionando personaje ID: {idPersonaje}");
        
        personajeSeleccionado = idPersonaje;
        GameState.SelectedCharacterID = idPersonaje; // Guardar en el estado global
        
        // Mostrar solo el personaje seleccionado
        if (pachecoColorido != null)
        {
            bool activarColorido = (idPersonaje == 0);
            pachecoColorido.SetActive(activarColorido);
            Debug.Log($"Pacheco Colorido: {(activarColorido ? "ACTIVO" : "INACTIVO")}");
        }
        else
        {
            Debug.LogError("❌ pachecoColorido es NULL!");
        }
            
        if (pachecoBlanco != null)
        {
            bool activarBlanco = (idPersonaje == 1);
            pachecoBlanco.SetActive(activarBlanco);
            Debug.Log($"Pacheco Blanco: {(activarBlanco ? "ACTIVO" : "INACTIVO")}");
        }
        else
        {
            Debug.LogError("❌ pachecoBlanco es NULL!");
        }
        
        // Mover indicador visual (si existe)
        MoverIndicadorSeleccion(idPersonaje);
        
        // Actualizar colores de botones
        ActualizarColoresBotones(idPersonaje);
        
        Debug.Log($"✅ Personaje seleccionado: {(idPersonaje == 0 ? "Pacheco Colorido" : "Pacheco Blanco")} (ID: {idPersonaje})");
    }
    
    void MoverIndicadorSeleccion(int idPersonaje)
    {
        if (indicadorSeleccion == null) return;
        
        // Mover el indicador al botón correspondiente
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
        // Cambiar color del botón seleccionado
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
    
    // Funciones para botones de navegación (opcional)
    public void SiguientePersonaje()
    {
        int siguiente = (personajeSeleccionado + 1) % 2; // Alternar entre 0 y 1
        SeleccionarPersonaje(siguiente);
    }
    
    public void AnteriorPersonaje()
    {
        int anterior = (personajeSeleccionado - 1 + 2) % 2; // Alternar entre 0 y 1
        SeleccionarPersonaje(anterior);
    }
}