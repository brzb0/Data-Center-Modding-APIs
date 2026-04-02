# Data Center Modding APIs

A C# SDK for building Data Center mods with MelonLoader and IL2CPP faster and more safely.

Clean wrappers are included for player data, network devices, UI, localisation, time, and world access.

## Quick Links

- MelonLoader requirements: https://melonwiki.xyz/#/?id=requirements
- Data Center on Steam: https://store.steampowered.com/app/4170200/Data_Center/

## Structure

- src/DataCenter.ModigAPIs: SDK library
- examples/Sample.ModigConsumer: sample mod that covers all features

## Requirements

- Data Center installed
- MelonLoader for .NET 6
- .NET SDK 6+

Default path used by the csproj files:

D:\Juegos\steamapps\common\Data Center

If your path is different, update the GameRoot property in both csproj files.

## How to Use

### 1. Install prerequisites

1. Install Data Center from Steam.
2. Install MelonLoader and complete its requirements.

### 2. Configure your game path

Update GameRoot in both project files if needed:

- src/DataCenter.ModigAPIs/DataCenter.ModigAPIs.csproj
- examples/Sample.ModigConsumer/Sample.ModigConsumer.csproj

### 3. Build the SDK

1. cd src/DataCenter.ModigAPIs
2. dotnet build -c Release

Output:

bin/Release/net6.0/DataCenter.ModigAPIs.dll

### 4. Build the sample mod

1. cd examples/Sample.ModigConsumer
2. dotnet build -c Release

Output:

bin/Release/net6.0/Sample.ModigConsumer.dll

### 5. Copy DLL files to the game Mods folder

Copy both files into your Data Center Mods folder:

- DataCenter.ModigAPIs.dll
- Sample.ModigConsumer.dll

Typical destination:

D:\Juegos\steamapps\common\Data Center\Mods

### 6. Launch and test

1. Start the game.
2. Open MelonLoader logs if you want to monitor runtime output.
3. Use the sample mod hotkeys listed below to test all SDK areas.

## API Reference

### ModigGame

Purpose:

Provides global access points and readiness checks before calling higher-level APIs.

Main methods:

- IsGameReady: true when PlayerManager and playerClass are available.
- GetPlayerRaw: returns the raw Il2Cpp Player instance.
- GetNetworkMapRaw: returns the raw NetworkMap singleton.
- GetUiRaw: returns the raw StaticUIElements singleton.
- GetTimeRaw: returns the raw TimeController singleton.
- GetLocalisationRaw: returns the raw Localisation singleton.

Use it when:

- You want to guard your logic before touching game objects.
- You need direct raw access for custom low-level behavior.

### PlayerApi

Purpose:

Reads and updates player progression and economy values with safe null checks.

Main methods:

- IsAvailable: checks whether player data is accessible.
- GetMoney, GetXp, GetReputation: read current values.
- TryAddMoney, TryAddXp, TryAddReputation: increment values.
- TrySetMoney, TrySetXp, TrySetReputation: target specific values using delta updates.
- GetRaw: returns the raw Player object.

Use it when:

- You are building rewards, penalties, admin tools, or balancing scripts.

### NetworkApi

Purpose:

Manages network infrastructure state (servers and switches), including snapshots, failures, and repairs.

Main methods:

- IsAvailable, GetRaw: network map availability and raw object access.
- GetServersSnapshot, GetSwitchesSnapshot: stable snapshots of all devices.
- GetBrokenServersSnapshot, GetBrokenSwitchesSnapshot: stable snapshots of broken devices.
- TryBreakServer, TryBreakSwitch: force a failure on a specific device.
- TryRepairServer, TryRepairSwitch: repair and optionally power devices on.
- RepairAllBrokenDevices: batch repair with safe snapshot iteration.
- GetCounts: returns totals and broken counts in one structure.

Use it when:

- You need event-driven outages, disaster simulation, or one-click recovery actions.

### UiApi

Purpose:

Displays user-facing information using in-game UI channels.

Main methods:

- IsAvailable, GetRaw: UI singleton checks and raw access.
- TryNotify: pushes a notification using text and optional localisation UID.
- TryAddMessage: appends text to the in-game message field.

Use it when:

- You want visible feedback for hotkeys, background jobs, or debugging states.

### LocalisationApi

Purpose:

Reads language state and retrieves localized text by ID.

Main methods:

- IsAvailable, GetRaw: localisation singleton checks and raw access.
- GetCurrentLanguageName: current language enum name.
- GetCurrentLanguageUid: current language UID used by the game.
- GetTextById: resolves a localisation entry by ID.
- TryChangeLanguage: changes language via UID.

Use it when:

- You need multilingual messages or want to test localisation-aware features.

### TimeApi

Purpose:

Reads and controls game time flow.

Main methods:

- IsAvailable, GetRaw: time singleton checks and raw access.
- GetCurrentDay: current in-game day.
- GetCurrentHour: current time in hours.
- GetTimeMultiplier: current simulation speed.
- TrySetTimeMultiplier: sets simulation speed.
- IsBetween: helper for time-window logic.

Use it when:

- You need schedules, day/night behavior, or accelerated simulation testing.

### WorldApi

Purpose:

Finds world objects related to shop/network map interactions.

Main methods:

- FindComputerShops: returns all ComputerShop objects found in scene.
- FindFirstShopWithNetworkMapScreen: first valid shop that has a network map screen.
- GetNetworkMapScreen: direct access to the network map screen GameObject.

Use it when:

- You need scene anchors for overlays, custom panels, or context-aware tools.

## Sample mod hotkeys

- F1: help
- F2: SDK core state and raw object availability
- F3: player add money/xp/reputation
- F4: player set money/xp/reputation
- F5: network counts
- F6: break one server and one switch
- F7: repair all broken devices
- F8: UI notification and UI message
- F9: localisation info and text lookup
- F10: change localisation to the same UID (API call test)
- F11: time read and toggle time multiplier
- F12: world scan (ComputerShop and network map screen)
