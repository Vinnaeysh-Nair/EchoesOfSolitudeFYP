using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RecordingScript : MonoBehaviour
{
    public Image image;
    public float blinkInterval = 1f; // Blinking interval in seconds

    private void Start()
    {
        // Invoke Repeatedly calls the method with the specified delay and interval
        InvokeRepeating("ToggleVisibility", 0f, blinkInterval);
    }

    private void ToggleVisibility()
    {
        // Toggle the image's visibility
        image.enabled = !image.enabled;
    }
}
