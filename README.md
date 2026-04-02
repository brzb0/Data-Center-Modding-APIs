# Data Center Modig APIs

A C# SDK for building Data Center mods with MelonLoader and IL2CPP faster and more safely.

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

## Build the SDK

1. cd src/DataCenter.ModigAPIs
2. dotnet build -c Release

Output:

bin/Release/net6.0/DataCenter.ModigAPIs.dll

## Build the sample mod

1. cd examples/Sample.ModigConsumer
2. dotnet build -c Release

Output:

bin/Release/net6.0/Sample.ModigConsumer.dll

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
