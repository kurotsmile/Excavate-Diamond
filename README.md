# Excavate Diamond

Excavate Diamond is a 2D match-style puzzle game built with Unity.
The player swaps adjacent tiles, creates matches, scores points, and plays against time.

The project currently includes a playable core loop, UI flow, audio feedback, animated effects, and a dynamic background system with randomized main backgrounds.

## Overview

This repository contains the Unity project for Excavate Diamond, including:

- Match-and-swap tile gameplay
- Score and combo handling
- Timer-based play session
- Main menu and game over flow
- Animated visual effects
- Audio feedback for taps, scoring, and wrong moves
- Randomized background selection between multiple background images
- Auto-scaled scrolling background for both the menu and gameplay screens

## Gameplay

The current gameplay loop is simple:

1. Start a new game from the main menu
2. Swap adjacent tiles to create matches
3. Earn points and trigger combos
4. Keep playing until the timer runs out
5. Review your score on the game over screen

## Controls

- Click or tap a tile to select it
- Click or tap an adjacent tile to swap
- Valid swaps that create matches will be processed
- Invalid swaps will revert automatically

## Main Features

- 2D tile board generated at runtime
- Randomized tile spawning
- Match detection and board refill
- Score tracking and high score support
- Combo-based scoring
- Tap, score, and wrong-move sound effects
- Menu, play, and game over UI panels
- Randomized `Board_bk` background using `bk.jpg` and `bk2.jpg`
- Background auto-fit for different screen sizes
- Subtle background movement for a more polished presentation

## Tech Stack

- Unity `6000.4.0f1`
- Universal Render Pipeline (URP)
- Unity Input System
- Unity UI (`uGUI`)
- C#

## Project Structure

Key folders:

- `Assets/Excavate-Diamond/Scripts`
  Core gameplay scripts such as board generation, tile behavior, score handling, game flow, and background control.

- `Assets/Excavate-Diamond/Prefabs`
  Prefabs for tiles and gameplay effects.

- `Assets/Excavate-Diamond/Images`
  Tile art, UI sprites, icons, and background images.

- `Assets/Excavate-Diamond/Audios`
  Sound effects used by the game.

- `Assets/Scenes`
  Scene assets for the project.

- `Assets/Settings`
  URP and renderer configuration assets.

## Important Scripts

- `BoardManager.cs`
  Handles board creation, tile swapping, match processing, drop/fill logic, and grid helpers.

- `TileController.cs`
  Handles tile input, selection, adjacency checks, matching, movement, and destruction.

- `Game_Handle.cs`
  Controls the main game flow, UI transitions, timer, score reset, and randomized background selection.

- `ScoreManager.cs`
  Manages score and high score values.

- `SoundManager.cs`
  Plays gameplay sound effects.

- `BoardBackgroundController.cs`
  Scales the background to fit the screen and adds subtle scrolling motion.

## Packages

Notable packages used in this project include:

- `com.unity.inputsystem`
- `com.unity.render-pipelines.universal`
- `com.unity.ugui`
- `com.unity.services.levelplay`
- `com.unity.purchasing`

See [Packages/manifest.json](/Users/rot/CR/Excavate%20Diamond/Packages/manifest.json) for the full dependency list.

## Getting Started

### Requirements

- Unity Editor `6000.4.0f1`

### Open the Project

1. Open Unity Hub
2. Add this repository as a local project
3. Open it with Unity `6000.4.0f1`

### Run the Game

1. Open the main gameplay scene in `Assets/Scenes`
2. Press Play in the Unity Editor

## Current State

The game is functional as a prototype and already has a complete basic gameplay loop.
It is a good base for expanding into:

- Multiple game modes
- Level-based progression
- Objectives and missions
- Special tiles and blockers
- Daily challenges
- Better progression and reward systems

## Future Ideas

- Move-limited mode
- Objective-based levels
- Endless mode
- Survival mode
- Puzzle mode
- Special power-up tiles
- Obstacle tiles such as stone, ice, or lava
- Better progression and unlock systems
- More background themes and stage environments

## Notes

- This project includes third-party services and framework integrations for ads and app-related systems.
- If package or service setup is incomplete on a machine, some integrations may need to be reconfigured before building for mobile.

## License

No license file is currently included in this repository.
Add a license if you plan to distribute or open-source the project.
