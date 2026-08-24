# 📘 Electric Field Visualization (VR + Desktop)

---

## 📌 Overview

This project is an **interactive Electric Field Visualization system** built using Unity.  
It allows users to **place electric charges, observe field lines, and interact with them** in both **Desktop and Virtual Reality (VR)** environments.

The objective is to provide an intuitive understanding of **electrostatic field behavior** through real-time visualization.

---

## 🎯 Features

### ⚡ Charge System
- Add **positive and negative charges**
- Select charges and:
  - Change magnitude (scroll / joystick)
  - Delete charges
- Charges scale visually based on magnitude
- Add Dipoles and Quadrupoles

---

### 🧲 Electric Field Visualization
- Real-time **electric field line rendering**
- Toggle:
  - Show / Hide field lines
- Field lines dynamically update based on charge configuration

---

### 🧪 Test Particle
- Spawn test particles
- Visualize field direction through particle motion

---

### 🖥️ Desktop Controls

| Action | Control |
|------|--------|
| Toggle HUD | `TAB` |
| Select Charge | Left Click |
| Change Magnitude | Mouse Scroll |
| Delete Charge | `Delete` Key |

---

### 🥽 VR Controls (Meta Quest)

| Action | Control |
|------|--------|
| Toggle HUD | `B` Button |
| Select Charge | Trigger (Ray) |
| Change Magnitude | Thumbstick (Up/Down) |
| Delete Charge | `A` Button |

---

### 🧩 UI / HUD
- Interactive HUD panel
- Includes:
  - Add Positive Charge
  - Add Negative Charge
  - Test Particle
  - Clear Charges
  - Toggle Field Lines
  - Add Dipole and Quadrupole
- Features:
  - Hover effect
  - Click animation
  - Sound feedback

---

### 🏷️ Charge Labels
- Displays charge magnitude (e.g., `+2.5 C`)
- Appears **only when a charge is selected**
- Always faces the user (billboard effect)

---

## 🏗️ Project Structure

Scenes/
├── MainMenu (Scene 0)
└── Lab Scene (Scene 1)

Scripts/
├── Charge.cs
├── ChargeInteractor.cs (Desktop)
├── VR_ChargeModifier.cs (VR)
├── FieldLineGenerator.cs
├── FieldLineToggle.cs
├── HUDManager.cs
├── VR_HUD_Toggle.cs

---

## 🔄 Scene Flow

Main Menu → Enter Lab → Interactive Simulation
↓
Back to Main Menu


---

## ⚙️ Setup Instructions

1. Open project in **Unity (2022.x recommended)**

2. Go to:

File → Build Settings

Ensure:
- Scene 0 → MainMenu  
- Scene 1 → Lab  

3. For VR:
- Connect Meta Quest headset
- Enable **Oculus / OpenXR Plugin**

4. Press **Play**

---

## 🚀 How to Use

1. Start from Main Menu  
2. Select and Enter VR Lab  
3. Press **TAB (Desktop)** or **B (VR)** to open HUD  
4. Add charges  
5. Select and modify them  
6. Observe electric field lines  
7. Spawn test particles  
8. Spawn dipoles and quadrupoles

---

## 🧠 Concepts Demonstrated

- Electric field behavior
- Field line distribution
- Charge interaction
- Force direction visualization

---

## 📦 Technologies Used

- Unity Engine
- C#
- Meta XR All in one SDK (OVR Modules)

---