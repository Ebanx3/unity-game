using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class Language : MonoBehaviour
{
    public GameObject languageDropdown;
    private TMP_Dropdown dropdown;

    void Awake(){
        dropdown = languageDropdown.GetComponent<TMP_Dropdown>();
        dropdown.value = LocalizationSettings.SelectedLocale.SortOrder;
    }

    public void ChangeLanguage()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[dropdown.value];
    }
}
