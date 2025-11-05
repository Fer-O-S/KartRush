# Guía de Colaboración - Proyecto GO!

## 📋 Información del Proyecto

- **Versión de Unity:** 2021.3.45f2
- **Tipo de proyecto:** 3D
- **Render Pipeline:** Built-in Render Pipeline

## 🔄 Flujo de Trabajo con Git

### Antes de empezar a trabajar:

```bash
git pull origin main
```

### Antes de hacer commit:

```bash
git add .
git commit -m "Descripción clara de los cambios"
git push origin main
```

## 📂 Archivos Importantes que NO debes modificar:

- `ProjectSettings/` - Configuraciones del proyecto
- `Packages/manifest.json` - Dependencias del proyecto
- Archivos `.meta` - Unity los genera automáticamente

## 🎨 Convenciones del Proyecto

### Nomenclatura de Assets:

- **Escenas:** `01_NombreEscena.unity`
- **Scripts:** `PascalCase.cs`
- **Materiales:** `nombreMaterial.mat`
- **Texturas:** `texture_nombre.png`

### Organización de carpetas:

```
Assets/
├── Scripts/
│   ├── Managers/        # GameFlowManager, etc.
│   ├── UI/             # Scripts de interfaz
│   └── Gameplay/       # Mecánicas del juego
├── Scenes/
├── Materials/
├── Textures/
└── Models/
```

## 🚨 Qué hacer si algo sale mal:

### Si Unity no reconoce scripts:

1. Ve a `Assets` → `Refresh`
2. O cierra Unity y vuelve a abrir el proyecto

### Si faltan referencias:

1. Selecciona el objeto con referencias rotas
2. Arrastra manualmente el asset correcto al campo vacío

### Si el proyecto se corrompe:

1. Haz backup de la carpeta `Assets/`
2. Elimina `Library/` y `Temp/`
3. Vuelve a abrir el proyecto en Unity

## 🔧 Configuraciones Técnicas

### Render Textures configuradas:

- `RT_KartView` - Para vista previa de karts
- `RT_PachecoView` - Para vista previa de personajes

### Scripts principales:

- `GameFlowManager.cs` - Control del flujo del juego
- `Rotator.cs` - Sistema de rotación

## 📱 Configuración de Build

- **Plataforma objetivo:** PC/Mobile (por definir)
- **Resolución:** Responsive
- **Orientación:** Landscape

## ✅ Checklist antes de hacer Push:

- [ ] El proyecto abre sin errores
- [ ] Todas las escenas cargan correctamente
- [ ] No hay referencias rotas en el Inspector
- [ ] Los scripts compilan sin errores
- [ ] Las interfaces funcionan como esperado

---

**💡 Tip:** Siempre prueba tu trabajo en una build de desarrollo antes de hacer push de cambios importantes.
