# ⚡ Electric Field Visualization — Interactive VR & Desktop Simulation

An interactive **electric field visualization system** built with **Unity** that lets you place electric charges, observe dynamically generated field lines, and explore electrostatic behavior in real time — in both **Desktop** and **VR (Meta Quest)** environments.

> Developed as part of the **DES643** course project. Includes a research paper, presentation, and a pre-built Windows executable for quick demos.

---

## 📋 Table of Contents

- [Features](#-features)
- [Demo — Quick Start (No Unity Needed)](#-demo--quick-start-no-unity-needed)
- [Prerequisites](#-prerequisites)
- [Setup & Installation](#-setup--installation)
- [How to Use](#-how-to-use)
- [Controls](#-controls)
- [Project Architecture](#-project-architecture)
- [Physics Under the Hood](#-physics-under-the-hood)
- [Repository Structure](#-repository-structure)
- [Contributing](#-contributing)
- [Technologies Used](#-technologies-used)
- [License](#-license)

---

## ✨ Features

### ⚡ Charge System
- Place **positive** (red) and **negative** (blue) charges anywhere in the 3D lab
- **Select** any charge to modify it:
  - Adjust magnitude with mouse scroll (Desktop) or thumbstick (VR)
  - Delete individual charges
- Charges **scale visually** based on their magnitude
- One-click **presets**: spawn a Dipole or Quadrupole configuration instantly
- **Clear all** charges with a single button

### 🧲 Real-Time Field Lines
- Electric field lines are **computed and rendered every frame** using Coulomb's law
- Lines originate from positive charges and terminate at negative charges
- Direction distribution uses the **golden-ratio sphere sampling** algorithm for even coverage
- **Toggle visibility** on/off from the HUD

### 🧪 Test Particles
- Spawn lightweight **test particles** into the field
- Particles experience force (`F = qE`), accelerate, and move along the field
- Built-in **damping** and **speed clamping** for stable visualization
- Auto-destroyed when they leave the simulation bounds

### 🏷️ Charge Labels
- Selected charges display their magnitude (e.g., `+2.5 C`)
- Labels use a **billboard effect** — always facing the camera

### 🎨 UI / HUD
- In-world interactive HUD panel with buttons for:
  - Add Positive / Negative Charge
  - Spawn Test Particle
  - Toggle Field Lines
  - Create Dipole / Quadrupole
  - Clear All Charges
- HUD features hover effects, click animations, and sound feedback
- Multi-page HUD navigation

### 🥽 Dual-Mode Support
- Seamless switching between **Desktop** and **VR** modes via `PlayerModeManager`
- Separate, dedicated control scripts for each platform
- VR mode supports Meta Quest headsets with ray-based interaction

---

## 🚀 Demo — Quick Start (No Unity Needed)

A **pre-built Windows executable is included right inside this repository** — no Unity installation, no compilation, no extra downloads required.

### ▶️ Play in 3 Steps

1. **Clone or download** this repository
2. **Navigate to** the Build folder:
   ```
   DES643_Project/Build/
   ```
3. **Double-click** `Efield_viz.exe` — the simulation launches instantly

> [!TIP]
> This is the fastest way to experience the project. The `Build/` directory contains a fully self-contained Windows build with all dependencies bundled (`UnityPlayer.dll`, `MonoBleedingEdge/`, data files, etc.). No setup needed — just run it!

> [!NOTE]
> The pre-built executable runs in **Desktop mode** only. For VR mode, you'll need to open the project in Unity (see [Setup & Installation](#-setup--installation) below).

---

## 📦 Prerequisites

To **open and modify** the project in the Unity Editor:

| Requirement | Details |
|---|---|
| **Unity** | 2022.x (LTS recommended) |
| **Platform** | Windows / macOS (editor); Windows (pre-built demo) |
| **VR (optional)** | Meta Quest headset + Oculus / OpenXR Plugin enabled |
| **SDK** | Meta XR All-in-One SDK (included in project) |

---

## 🔧 Setup & Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Rahaman146/ElectricField_Visualization.git
   cd ElectricField_Visualization
   ```

2. **Open in Unity Hub**
   - Add the project folder: `DES643_Project/Prototype Artefact`
   - Unity will import all assets automatically

3. **Verify Build Settings**
   - `File → Build Settings`
   - Ensure the scene order is:
     | Index | Scene |
     |-------|-------|
     | 0 | `Main_Menu` |
     | 1 | `Lab_Scene` |

4. **For VR mode** *(optional)*
   - Connect your Meta Quest headset via Link / Air Link
   - Enable **Oculus** or **OpenXR Plugin** under `Edit → Project Settings → XR Plug-in Management`
   - In `PlayerModeManager.cs`, set `useVR = true`

5. **Press ▶ Play** in the Unity Editor

---

## 🎮 How to Use

1. Launch from the **Main Menu**
2. Enter the **Lab Scene**
3. Open the **HUD** (`TAB` on Desktop / `B` on VR)
4. **Add charges** — positive or negative
5. **Select** a charge to adjust its magnitude or delete it
6. Watch **electric field lines** update in real time
7. **Spawn test particles** to see them move through the field
8. Try the **Dipole** and **Quadrupole** presets for classic configurations
9. **Toggle field lines** on/off for a cleaner view

---

## 🕹️ Controls

### 🖥️ Desktop

| Action | Control |
|---|---|
| Open / Close HUD | `TAB` |
| Look Around | Mouse (with toggle) |
| Move | `W` `A` `S` `D` |
| Select Charge | Left Click |
| Change Magnitude | Mouse Scroll Wheel |
| Delete Charge | `Delete` key |
| Drag Charge | Click & Drag |

### 🥽 VR (Meta Quest)

| Action | Control |
|---|---|
| Open / Close HUD | `B` Button |
| Select Charge | Trigger (Ray) |
| Change Magnitude | Thumbstick Up / Down |
| Delete Charge | `A` Button |

---

## 🏗️ Project Architecture

### Scene Flow

```
Main Menu  →  Lab Scene (Interactive Simulation)
    ↑               |
    └───────────────┘
         Back
```

### Core Scripts

| Script | Responsibility |
|---|---|
| [`ElectricFieldManager.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/ElectricFieldManager.cs) | Computes the net electric field **E** at any point using Coulomb's law |
| [`Charge.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/Charge.cs) | Represents a charge entity — magnitude, visual scaling, label display |
| [`FieldLineGenerator.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/FieldLineGenerator.cs) | Generates and renders field lines from positive charges using golden-ratio sampling |
| [`FieldLineToggle.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/FieldLineToggle.cs) | Toggles field line visibility on/off |
| [`TestParticle.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/TestParticle.cs) | Simulates a charged particle moving under the influence of the field |
| [`TestParticleSpawner.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/TestParticleSpawner.cs) | Spawns test particles into the scene |
| [`PresetManager.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/PresetManager.cs) | Creates preset charge configurations (Dipole, Quadrupole) |
| [`PlayerModeManager.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/PlayerModeManager.cs) | Switches between Desktop and VR player rigs at runtime |
| [`HUDManager.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/HUDManager.cs) | Manages HUD UI panel state |
| [`HUDPageManager.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/HUDPageManager.cs) | Handles multi-page HUD navigation |
| [`BillBoard.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/BillBoard.cs) | Keeps charge labels always facing the camera |
| [`AudioManager.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/AudioManager.cs) | Manages audio playback and SFX volume |
| [`SceneLoader.cs`](file:///c:/Users/rahaman/projects/ElectricField_Visualization/DES643_Project/Prototype%20Artefact/Assets/Scripts/SceneLoader.cs) | Handles scene transitions |

### Platform-Specific Scripts

**Desktop** (`Scripts/Desktop scripts/`):
`ChargeInteractor`, `ChargeDrag_Desktop`, `ChargeSpawner_Desktop`, `DesktopMovement`, `HUD_Follow_Desktop`, `HUD_Toggle_Desktop`, `MouseLookToggle`

**VR** (`Scripts/VR scripts/`):
`VR_ChargeModifier`, `VR_HUD_Toggle`

---

## 🧠 Physics Under the Hood

### Electric Field Calculation

The field at any point **p** is the vector sum of contributions from every charge:

$$\vec{E}(\mathbf{p}) = k \sum_{i} \frac{q_i}{|\mathbf{r}_i|^2} \hat{\mathbf{r}}_i$$

where $\mathbf{r}_i = \mathbf{p} - \mathbf{p}_i$ is the displacement from charge *i* to point **p**, and *k* is a scaled Coulomb constant.

### Field Line Generation

- Lines emanate **only from positive charges**
- Starting directions are distributed evenly on a sphere using the **Fibonacci / golden-ratio** algorithm
- Each line is traced step-by-step through the field with an **adaptive step size** (smaller steps in stronger fields)
- Lines **terminate** when they reach a negative charge (within a threshold distance) or when the field becomes negligibly weak

### Test Particle Dynamics

- Force: $\vec{F} = q\vec{E}$
- Velocity is updated via Euler integration with **damping** (factor 0.98) and **speed clamping** (max 5 units/s)
- Particles are auto-destroyed if they drift beyond 15 units from the origin

---

## 📂 Repository Structure

```
ElectricField_Visualization/
├── README.md                          ← You are here
├── DES643_Project/
│   ├── Readme.md                      ← Original project readme
│   ├── Research_Paper.pdf             ← Academic research paper
│   ├── Presentation.pptx              ← Project presentation slides
│   ├── Build/
│   │   └── Efield_viz.exe             ← Pre-built Windows executable
│   └── Prototype Artefact/            ← Unity project root
│       ├── Assets/
│       │   ├── Scripts/               ← All C# source code
│       │   │   ├── Desktop scripts/   ← Desktop-specific controls
│       │   │   └── VR scripts/        ← VR-specific controls
│       │   ├── Scenes/                ← Main_Menu & Lab_Scene
│       │   ├── Prefabs/               ← Charge, FieldLine, TestParticle, VR player
│       │   ├── Resources/             ← Runtime-loaded assets
│       │   ├── Oculus/                ← Meta XR SDK assets
│       │   ├── XR/                    ← XR interaction assets
│       │   └── SlimUI/                ← UI menu framework (3rd party)
│       ├── Packages/
│       ├── ProjectSettings/
│       └── UserSettings/
```

---

## 🤝 Contributing

Contributions are welcome! Here's how to get started:

1. **Fork** the repository
2. **Create a branch** for your feature or fix:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Commit** your changes with clear messages
4. **Push** to your fork and open a **Pull Request**

### Ideas for Contributions
- 🎨 Add a heatmap / vector field overlay
- 📊 Display equipotential surfaces
- 🔢 Show net force and torque calculations on-screen
- 🌐 WebGL build for browser-based demos
- 🎓 Guided tutorial mode for students

---

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| **Unity Engine** (2022.x) | Game engine and 3D rendering |
| **C#** | All scripting and simulation logic |
| **Meta XR All-in-One SDK** | VR support for Meta Quest headsets |
| **TextMesh Pro** | High-quality text rendering for charge labels |
| **SlimUI** | Modern menu UI framework |
| **Git LFS** | Large file storage for binary assets |

---

## 📄 License

This project is part of academic coursework (DES643). Please contact the repository owner for licensing and usage details.

---

<p align="center">
  <b>⭐ If you found this useful, give the repo a star!</b>
</p>
