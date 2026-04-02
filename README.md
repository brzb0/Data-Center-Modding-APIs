# Data Center Modding APIs

A C# SDK for building Data Center mods with MelonLoader and IL2CPP faster and more safely.

Clean wrappers are included for player data, network devices, UI, localisation, time, and world access.

## Quick Links

| Resource | Link |
| --- | --- |
| MelonLoader | [MelonLoader](https://melonwiki.xyz/#/) |
| Data Center | [Data Center on Steam](https://store.steampowered.com/app/4170200/Data_Center/) |

## Structure

| Path | Purpose |
| --- | --- |
| src/DataCenter.ModigAPIs | SDK library |
| examples/Sample.ModigConsumer | Sample mod that covers all features |

## Requirements

| Requirement | Notes |
| --- | --- |
| Data Center | Installed from Steam |
| MelonLoader | Compatible setup for .NET 6 |
| .NET SDK | Version 6+ |

Default path used by the csproj files:

D:\Juegos\steamapps\common\Data Center

If your path is different, update the GameRoot property in both csproj files.

## How to Use

| Step | Action | Details |
| --- | --- | --- |
| 1 | Install prerequisites | Install Data Center and MelonLoader |
| 2 | Configure game path | Update GameRoot in src/DataCenter.ModigAPIs/DataCenter.ModigAPIs.csproj and examples/Sample.ModigConsumer/Sample.ModigConsumer.csproj |
| 3 | Build SDK | Run: cd src/DataCenter.ModigAPIs then dotnet build -c Release |
| 4 | Build sample mod | Run: cd examples/Sample.ModigConsumer then dotnet build -c Release |
| 5 | Copy DLL files | Copy DataCenter.ModigAPIs.dll and Sample.ModigConsumer.dll to D:\Juegos\steamapps\common\Data Center\Mods |
| 6 | Launch and test | Start the game, check logs, then test hotkeys |

Build outputs:

| Project | Output DLL |
| --- | --- |
| DataCenter.ModigAPIs | bin/Release/net6.0/DataCenter.ModigAPIs.dll |
| Sample.ModigConsumer | bin/Release/net6.0/Sample.ModigConsumer.dll |

## API Reference

| API | Purpose | Key methods | Typical use |
| --- | --- | --- | --- |
| ModigGame | Global readiness checks and raw singleton access | IsGameReady, GetPlayerRaw, GetNetworkMapRaw, GetUiRaw, GetTimeRaw, GetLocalisationRaw | Guard your logic before accessing game systems and use raw objects for advanced integrations |
| PlayerApi | Safe player economy and progression control | IsAvailable, GetMoney, GetXp, GetReputation, TryAddMoney, TrySetMoney, TryAddXp, TrySetXp, TryAddReputation, TrySetReputation, GetRaw | Rewards, penalties, balancing tools, progression automation |
| NetworkApi | Device snapshots, failure simulation, and repair flows | IsAvailable, GetRaw, GetServersSnapshot, GetSwitchesSnapshot, GetBrokenServersSnapshot, GetBrokenSwitchesSnapshot, TryBreakServer, TryBreakSwitch, TryRepairServer, TryRepairSwitch, RepairAllBrokenDevices, GetCounts | Outage events, incident testing, one-click infrastructure recovery |
| UiApi | In-game feedback surfaces for player-visible messages | IsAvailable, GetRaw, TryNotify, TryAddMessage | Hotkey feedback, status notifications, runtime diagnostics |
| LocalisationApi | Language state and localized text lookup | IsAvailable, GetRaw, GetCurrentLanguageName, GetCurrentLanguageUid, GetTextById, TryChangeLanguage | Multilingual messaging and localization-aware behavior |
| TimeApi | Time reading and simulation speed control | IsAvailable, GetRaw, GetCurrentDay, GetCurrentHour, GetTimeMultiplier, TrySetTimeMultiplier, IsBetween | Schedules, day/night logic, fast-forward testing |
| WorldApi | Scene-level world object discovery helpers | FindComputerShops, FindFirstShopWithNetworkMapScreen, GetNetworkMapScreen | Attaching overlays and building context-aware world tools |

## Sample mod hotkeys

| Key | Action |
| --- | --- |
| F1 | Help |
| F2 | SDK core state and raw object availability |
| F3 | Player add money/xp/reputation |
| F4 | Player set money/xp/reputation |
| F5 | Network counts |
| F6 | Break one server and one switch |
| F7 | Repair all broken devices |
| F8 | UI notification and UI message |
| F9 | Localisation info and text lookup |
| F10 | Change localisation to the same UID (API call test) |
| F11 | Time read and toggle time multiplier |
| F12 | World scan (ComputerShop and network map screen) |
