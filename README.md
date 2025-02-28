# SpawnLatecomers

## Description
**SpawnLatecomers** is a plugin for **SCP: Secret Laboratory** servers using **Exiled API**. It automatically spawns late-joining players if they connect within a specified time after the round starts.

## Features
- Automatically spawns players who join after the round has started.
- Flexible time setting for late spawns.
- Customizable list of roles that late-joining players can receive.

## Installation
1. Make sure you have **Exiled** installed.
2. Download **SpawnLatecomers.dll** and place it in the `Plugins` folder on your server.
3. Restart the server.

## Configuration
A configuration file will be generated automatically after the first run. The following settings are available:

```yaml
is_enabled: true  # Enable or disable the plugin
debug: false      # Enable debug mode
TimeInSeconds: 60 # Time (in seconds) after the round starts during which players can spawn
RoleTypes:        # List of roles available for spawning
  - FacilityGuard
  - ClassD
  - Scientist
```

## How It Works
- If a player connects after the round starts and **less than X seconds** have passed, they are automatically assigned a random role from the list.

## Authors
- **Minect** — Development and support.
