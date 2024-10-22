using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioSource audioSource;  // Asigna aquí el Audio Source
    public Slider volumeSlider;      // Asigna aquí el Slider

    private void Start()
    {
        // Establecer el valor inicial del slider según el volumen actual
        volumeSlider.value = audioSource.volume;

        // Suscribirse al evento de cambio de valor del slider
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Método para cambiar el volumen basado en el valor del slider
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
