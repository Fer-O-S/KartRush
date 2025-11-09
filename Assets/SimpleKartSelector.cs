using UnityEngine;
using UnityEngine.UI;

public class SimpleKartSelector : MonoBehaviour
{
    [Header("Modelos de Carros")]
    public GameObject carroRojoAmarillo;  // Carro rojo/amarillo
    public GameObject carroAzul;          // Carro azul
    
    [Header("Botones de Selección")]
    public Button botonCarroRojoAmarillo; // Botón para seleccionar carro rojo/amarillo
    public Button botonCarroAzul;         // Botón para seleccionar carro azul
    
    [Header("Indicador Visual (Opcional)")]
    public GameObject indicadorSeleccion; // Marco o indicador que se mueve
    
    [Header("Información de Carros (Opcional)")]
    public Text nombreCarro;              // Texto para mostrar nombre del carro
    public Text estadisticasCarro;        // Texto para mostrar estadísticas
    
    private int carroSeleccionado = 0;    // 0 = Rojo/Amarillo, 1 = Azul

    void Start()
    {
        Debug.Log("🏎️ Iniciando SimpleKartSelector...");
        
        // Verificar que los modelos estén asignados
        if (carroRojoAmarillo == null)
            Debug.LogError("❌ Carro Rojo/Amarillo no está asignado en el Inspector!");
        if (carroAzul == null)
            Debug.LogError("❌ Carro Azul no está asignado en el Inspector!");
        
        // Configurar los botones
        if (botonCarroRojoAmarillo != null)
        {
            botonCarroRojoAmarillo.onClick.AddListener(() => SeleccionarCarro(0));
            Debug.Log("✅ Botón Carro Rojo/Amarillo configurado");
        }
        else
        {
            Debug.LogWarning("⚠️ Botón Carro Rojo/Amarillo no está asignado");
        }
            
        if (botonCarroAzul != null)
        {
            botonCarroAzul.onClick.AddListener(() => SeleccionarCarro(1));
            Debug.Log("✅ Botón Carro Azul configurado");
        }
        else
        {
            Debug.LogWarning("⚠️ Botón Carro Azul no está asignado");
        }
        
        // Mostrar carro inicial
        SeleccionarCarro(GameState.SelectedKartID);
    }

    public void SeleccionarCarro(int idCarro)
    {
        Debug.Log($"🎯 Seleccionando carro ID: {idCarro}");
        
        carroSeleccionado = idCarro;
        GameState.SelectedKartID = idCarro; // Guardar en el estado global
        
        // Mostrar solo el carro seleccionado
        if (carroRojoAmarillo != null)
        {
            bool activarRojoAmarillo = (idCarro == 0);
            carroRojoAmarillo.SetActive(activarRojoAmarillo);
            Debug.Log($"Carro Rojo/Amarillo: {(activarRojoAmarillo ? "ACTIVO" : "INACTIVO")}");
        }
        else
        {
            Debug.LogError("❌ carroRojoAmarillo es NULL!");
        }
            
        if (carroAzul != null)
        {
            bool activarAzul = (idCarro == 1);
            carroAzul.SetActive(activarAzul);
            Debug.Log($"Carro Azul: {(activarAzul ? "ACTIVO" : "INACTIVO")}");
        }
        else
        {
            Debug.LogError("❌ carroAzul es NULL!");
        }
        
        // Mover indicador visual (si existe)
        MoverIndicadorSeleccion(idCarro);
        
        // Actualizar colores de botones
        ActualizarColoresBotones(idCarro);
        
        // Actualizar información del carro
        ActualizarInfoCarro(idCarro);
        
        Debug.Log($"🏎️ Carro seleccionado: {(idCarro == 0 ? "Carro Rojo/Amarillo" : "Carro Azul")} (ID: {idCarro})");
    }
    
    void MoverIndicadorSeleccion(int idCarro)
    {
        if (indicadorSeleccion == null) return;
        
        // Mover el indicador al botón correspondiente
        if (idCarro == 0 && botonCarroRojoAmarillo != null)
        {
            indicadorSeleccion.transform.position = botonCarroRojoAmarillo.transform.position;
        }
        else if (idCarro == 1 && botonCarroAzul != null)
        {
            indicadorSeleccion.transform.position = botonCarroAzul.transform.position;
        }
    }
    
    void ActualizarColoresBotones(int idCarro)
    {
        // Cambiar color del botón seleccionado
        if (botonCarroRojoAmarillo != null)
        {
            ColorBlock colores = botonCarroRojoAmarillo.colors;
            colores.normalColor = (idCarro == 0) ? Color.green : Color.white;
            botonCarroRojoAmarillo.colors = colores;
        }
        
        if (botonCarroAzul != null)
        {
            ColorBlock colores = botonCarroAzul.colors;
            colores.normalColor = (idCarro == 1) ? Color.green : Color.white;
            botonCarroAzul.colors = colores;
        }
    }
    
    void ActualizarInfoCarro(int idCarro)
    {
        if (nombreCarro != null)
        {
            nombreCarro.text = (idCarro == 0) ? "Carro Rápido" : "Carro Resistente";
        }
        
        if (estadisticasCarro != null)
        {
            if (idCarro == 0)
            {
                estadisticasCarro.text = "Velocidad: ★★★★☆\nAceleración: ★★★★★\nManejo: ★★★☆☆";
            }
            else
            {
                estadisticasCarro.text = "Velocidad: ★★★☆☆\nAceleración: ★★★☆☆\nManejo: ★★★★★";
            }
        }
    }
    
    // Funciones para botones de navegación (opcional)
    public void SiguienteCarro()
    {
        int siguiente = (carroSeleccionado + 1) % 2; // Alternar entre 0 y 1
        SeleccionarCarro(siguiente);
    }
    
    public void AnteriorCarro()
    {
        int anterior = (carroSeleccionado - 1 + 2) % 2; // Alternar entre 0 y 1
        SeleccionarCarro(anterior);
    }
}