using UnityEngine;

public class TogglePanel : MonoBehaviour
{
    public GameObject panel; // Asigna aquí el Panel desde el editor

    // Método para alternar la visibilidad del panel
    public void TogglePanelVisibility()
    {
        panel.SetActive(!panel.activeSelf); // Cambia el estado activo del panel (mostrar/ocultar)
    }
}
