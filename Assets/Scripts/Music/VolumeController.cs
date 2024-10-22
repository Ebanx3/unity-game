using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;  // Asigna aqu� el Audio Source
    public Slider volumeSlider;      // Asigna aqu� el Slider

    private void Start()
    {
        // Establecer el valor inicial del slider seg�n el volumen actual
        volumeSlider.value = audioSource.volume;

        // Suscribirse al evento de cambio de valor del slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // M�todo para cambiar el volumen basado en el valor del slider
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
