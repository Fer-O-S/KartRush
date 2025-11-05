using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Define la velocidad de giro en grados por segundo. 
    public float velocidadDeGiro = 60f;

    // Enum para seleccionar el eje de rotación fácilmente en el Inspector
    public enum RotationAxis { Y_Arriba, X_Derecha, Z_Adelante }
    public RotationAxis ejeDeRotacion = RotationAxis.Y_Arriba;

    void Update()
    {
        Vector3 rotationVector = Vector3.up; // Por defecto: Eje Y

        switch (ejeDeRotacion)
        {
            case RotationAxis.Y_Arriba:
                rotationVector = Vector3.up;     // Eje Y (personaje)
                break;
            case RotationAxis.X_Derecha:
                rotationVector = Vector3.right;  // Eje X
                break;
            case RotationAxis.Z_Adelante:
                rotationVector = Vector3.forward; // Eje Z (coche inclinado)
                break;
        }

        // Rota el objeto en el eje seleccionado
        transform.Rotate(rotationVector * velocidadDeGiro * Time.deltaTime);
    }
}