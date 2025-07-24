using UnityEngine;

[RequireComponent(typeof(Light))]
public class ValveLightstyleFlicker : MonoBehaviour
{
    // If true, the light flicker pattern is selected from predefined presets.
    // If false, a custom pattern string will be used instead.
    [SerializeField] private bool _usePreset = false;

    // The ID of the selected preset pattern from LightstylePresets.
    // This is used only if _usePreset is true.
    [SerializeField] private string _presetID = "Normal";

    // Light animation pattern: each character represents brightness level from 'a' (no light) to 'z' (maximum intensity)
    [SerializeField] private string _customPattern = "mmamammmmammamamaaamammma";

    // Maximum intensity value for the Light component
    [SerializeField] private float _maxIntensity = 2f;

    // Number of light updates per second (frames per second for flicker)
    [SerializeField] private float _updatesPerSecond = 10f;

    private Light _light;
    private string _lightstyle;
    private float _timer;
    private int _frame;
    private float _frameTime;

    void Start()
    {
        _light = GetComponent<Light>();
        if (_light == null)
        {
            Debug.LogWarning($"Light component missing on '{gameObject.name}'. Disabling.");
            enabled = false;
            return;
        }

        UpdatePattern();
        _frameTime = 1f / _updatesPerSecond;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _frameTime)
        {
            _timer -= _frameTime;

            _frame = (_frame + 1) % _lightstyle.Length;  // Advance to next frame in the pattern, looping back to start
            char frameChar = _lightstyle[_frame]; // Get current brightness character from the lightstyle pattern
            int charIndex = frameChar - 'a'; // Convert character to zero-based index (0 to 25)
            float intensity = Mathf.Clamp01(charIndex / 25f); // Normalize intensity between 0 and 1

            _light.intensity = intensity * _maxIntensity; // Set the Light component intensity scaled by maxIntensity
        }
    }

    private void UpdatePattern()
    {
        if (_usePreset)
        {
            var preset = ValveLightstylePresets.GetByID(_presetID); // If using a preset, try to find the preset by its ID
            _lightstyle = preset != null ? preset.Pattern : "m"; // If preset is found, use its pattern; otherwise, fallback to default pattern "m"
        }
        else
        {
            _lightstyle = string.IsNullOrEmpty(_customPattern) ? "m" : _customPattern; // If not using preset, use the custom pattern if it's not empty; otherwise, fallback to default pattern "m"
        }
    }

    private void OnValidate()
    {
        UpdatePattern();
    }
}
