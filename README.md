# RACE AI - Unity Racing AI Simulation

---

## Overview

**GS RACE AI** is a sophisticated Unity-based racing AI simulation project designed for autonomous vehicle behavior in racing scenarios. The project demonstrates professional-grade AI systems, advanced vehicle physics, and multi-agent racing capabilities.

This platform is ideal for research, game development, and AI-driven simulation for racing games.

---

## Features

### Vehicle Physics
- Realistic wheel colliders and suspension
- Configurable drive types: FWD, RWD, AWD
- 5-speed gear system with torque distribution
- Differential system for stability and torque vectoring
- Pacejka tire model for professional tire simulation
- Speed-adaptive steering sensitivity
- Advanced telemetry integration via `SpeedMeterUI`

### AI Systems
- Pathfinding using Unity NavMesh
- Rule-based decision making: braking, overtaking, reversing
- Multi-sensor obstacle detection (8 directions)
- Real-time opponent analysis and tactical behavior
- Drafting and cornering optimization
- Multi-agent team coordination
- Weather adaptation: Rain, Fog, Snow

### Game & Scene Management
- Dynamic AI and player vehicle spawning
- Race position tracking and lap counting
- Smooth camera transitions
- Simulation speed controls and pause/reset functionality
- Multi-car race scenarios (2-4 AI cars)
- Player vs AI integration
- Complex urban and track environments

### Editor & Debugging Tools
- Waypoints editor for custom track setup
- Gizmos for pathfinding and sensor debugging
- Dynamic UI system for per-vehicle telemetry

---

## Project Architecture
```
GS-RACE-AI/
├─ Core/
│  ├─ VehicleController.cs
│  ├─ DifferentialSystem.cs
│  ├─ PacejkaTireModel.cs
│  └─ SpeedMeterUI.cs
├─ ModulePathfinding/
│  ├─ WaypointsSystem.cs
│  ├─ WaypointsContainer.cs
│  └─ WaypointsNavigator.cs
├─ ModuleDecisionTree/
│  ├─ DecisionMakingSystem.cs
│  └─ DecisionComments.cs
├─ ModuleTactical/
│  ├─ ObstacleAvoidanceSystem.cs
│  ├─ ObstacleDetectionSensor.cs
│  ├─ OpponentsManager.cs
│  └─ TacticalSystem.cs
├─ GameManagement/
│  ├─ GamePlayManager.cs
│  ├─ SimpleRacePositionSystem.cs
│  └─ UIManager.cs
├─ UserInput/
│  └─ UserInput.cs
├─ EditorTools/
│  └─ WaypointsEditor.cs
└─ Scenes/
├─ Scene0 - Scene8
└─ CityScene
```
---

## Technical Highlights
- Modular architecture using **partial classes** for clean separation
- Optimized AI pathfinding and sensor systems
- Plugin-ready design for extensibility
- Real-time adaptation for environment and opponent behavior
- Industry-standard physics and tire models
- Comprehensive debugging and telemetry tools

---

## Scenes Overview
| Scene | Description |
|-------|-------------|
| Scene 0 | Basic car controller & AI |
| Scene 1 | Car model showcase |
| Scene 2 | Static obstacle navigation |
| Scene 3 | Dynamic obstacle avoidance |
| Scene 4 | Player vs single AI |
| Scene 5 | Differential system demonstration |
| Scene 6 | 2 AI cars racing |
| Scene 7 | 4 AI cars competition |
| Scene 8 | Player vs 3 AI cars |
| City Scene | Complex urban environment racing |

---

## Getting Started

### Requirements
- Unity 2021.3+ or higher
- Windows/macOS/Linux
- Standard Input devices for player testing

### Installation
1. Clone the repository
```bash
git clone <repository-url>
````

2. Open in Unity
3. Load desired scene from `Scenes/` folder
4. Press Play to run the simulation

### Running AI Simulations

* Select AI vehicles and assign their behaviors
* Configure waypoint tracks
* Adjust weather parameters if needed
* Observe tactical decision-making and racing dynamics

---

## Contributing

* Contributions are welcome via pull requests
* Please maintain descriptive commit messages
* Follow the modular architecture and naming conventions

---

## License

This project is proprietary to **Gamescepter**.
For commercial or research licensing, please contact [Gamescepter](https://gamescepter.com/gs-race-ai).

---

## References

* [GS RACE AI Website](https://gamescepter.com/gs-race-ai)
* Internal Project Documentation & Architecture Review

---

### ✅ **Notes**
- All **core systems, AI modules, physics systems** from your document included  
- **Scenes table** added for clarity  
- Clean Markdown, badges, headings — GitHub friendly  
- “Getting Started” + “Contributing” sections included for repo usage  

