# GO! - Proyecto Unity

## 🚀 Configuración del Proyecto

Este es un proyecto de Unity con interfaces ya configuradas. Sigue estos pasos para configurarlo correctamente:

### Requisitos Previos
- Unity 2022.3 LTS o superior (recomendado)
- Git instalado en tu sistema

### 📥 Configuración Inicial

1. **Clona el repositorio:**
   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd "GO!"
   ```

2. **Abre el proyecto en Unity:**
   - Abre Unity Hub
   - Haz clic en "Open" o "Agregar"
   - Navega hasta la carpeta del proyecto clonado
   - Selecciona la carpeta raíz (donde está este README.md)
   - Unity detectará automáticamente el proyecto

3. **Primera apertura:**
   - Unity puede tardar unos minutos en importar y procesar todos los assets
   - Deja que Unity complete la importación inicial
   - **NO** interrumpas este proceso

### 🎮 Escenas Disponibles

El proyecto incluye las siguientes escenas configuradas:
- `02_SelectCharacter.unity` - Selección de personaje
- `03_SelectKart.unity` - Selección de kart
- `04_SelectTrack.unity` - Selección de pista

### 📁 Estructura del Proyecto

```
Assets/
├── Scenes/              # Escenas del juego
├── Scripts/             # Scripts C#
├── Materials/           # Materiales
├── Models/              # Modelos 3D (.fbx)
└── Textures/           # Texturas e imágenes
```

### ⚙️ Scripts Principales

- `GameFlowManager.cs` - Gestor principal del flujo del juego
- `Rotator.cs` - Sistema de rotación de objetos

### 🔧 Configuración de Renderizado

El proyecto utiliza:
- Render Textures configuradas (`RT_KartView`, `RT_PachecoView`)
- TextMesh Pro para interfaces de texto

### ❗ Importante

- **NO** modifiques archivos en las carpetas `Library/`, `Temp/`, o `Logs/`
- Estas carpetas se regeneran automáticamente
- Siempre trabaja desde la carpeta `Assets/`

### 🐛 Resolución de Problemas

**Si el proyecto no abre correctamente:**
1. Verifica que estés usando Unity 2022.3 LTS o superior
2. Elimina las carpetas `Library/` y `Temp/` 
3. Vuelve a abrir el proyecto en Unity
4. Permite que Unity regenere estos archivos

**Si faltan referencias en los scripts:**
1. Selecciona todos los scripts en `Assets/`
2. Click derecho → "Reimport"
3. Unity debería resolver las referencias automáticamente

### 📞 Soporte

Si tienes problemas para configurar el proyecto, contacta al equipo de desarrollo.

---
*Última actualización: Noviembre 2025*