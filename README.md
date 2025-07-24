# Valve Lightstyle Flicker for Unity

This Unity script implements Quake-style light flickering by using a string pattern to control brightness levels over time. It replicates the original lightstyle technique used in the Quake and Source engines, allowing for authentic and efficient light animation without complex setups.

## Features
- Uses a string pattern ('a' to 'z') to define brightness levels.  
- Adjustable maximum light intensity.  
- Configurable update frequency.  
- **Built-in light flicker presets** for quick and easy setup of common effects like candle flicker, fluorescent flicker, pulses, and strobes.  
- Option to use custom patterns for full creative control.

## Usage
1. Attach the script to a GameObject with a Light component.  
2. Choose a preset from the dropdown or enter your own custom pattern in the Inspector.  
3. Customize the Max Intensity and Updates Per Second fields to fine-tune the flicker effect.

## Why use presets?
- Save time with ready-made flicker patterns crafted to deliver a variety of atmospheric lighting effects effortlessly. 
- Easily switch between diverse lighting moods without crafting complex patterns yourself.  
- Ideal for rapid prototyping and polishing lighting atmosphere.

## Notes
- This script updates the light intensity every frame regardless of player distance or visibility.  
- For better performance in large scenes, consider adding distance checks or visibility culling.

## References
- [Valve Developer Wiki – Lightstyle](https://developer.valvesoftware.com/wiki/Lightstyle)  
- [Quake Source Code (id Software on GitHub)](https://github.com/id-Software/Quake)