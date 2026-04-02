# Data Center Modig APIs

A C# SDK for building Data Center mods with MelonLoader and IL2CPP faster and safer.

Clean wrappers are included for player data, network devices, UI, localisation, time, and world access.

## Quick Links

- MelonLoader requirements: https://melonwiki.xyz/#/?id=requirements
- Data Center on Steam: https://store.steampowered.com/app/4170200/Data_Center/

## Structure

- src/DataCenter.ModigAPIs: SDK library
- examples/Sample.ModigConsumer: sample mod that covers all features

## Requirements

- Data Center installed
- MelonLoader for net6
- .NET SDK 6+

Default path used by the csproj files:

D:\Juegos\steamapps\common\Data Center

If your path is different, update the GameRoot property in both csproj files.

## How To Use

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

## Included APIs

- ModigGame
- PlayerApi
- NetworkApi
- UiApi
- LocalisationApi
- TimeApi
- WorldApi

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
