using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject helpMenu;

    [Header("Input Action")]
    [SerializeField] private InputActionProperty openMenu;

    [Header("Slider")]
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI sliderValueText;
    [SerializeField] private float sliderValue;
    
    [Header("Dropdown")]
    [SerializeField] private string optionValue;

    [Header("Toggle")]
    [SerializeField] private Toggle deleteToggle;
    [SerializeField] private Toggle changeToggle;

    [Header("Scrollview")]
    [SerializeField] private GameObject content;

    [Header("Prefab")]
    [SerializeField] private GameObject itemPrefab;

    private bool _isPauseMenuOpen = false;
    
    private void Awake()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
        pauseMenu.SetActive(false);

        sliderValueText.text = slider.value.ToString("0");
        sliderValue = slider.value;
        optionValue = "Option A";
    }

    private void Update()
    {
        if (openMenu.action.WasPressedThisFrame())
        {
            TogglePauseMenu();
        }
    }

    public void TogglePauseMenu()
    {
        _isPauseMenuOpen = !_isPauseMenuOpen;
        pauseMenu.SetActive(_isPauseMenuOpen);
    }
    
    public void ResumeGame()
    {
        pauseMenu.SetActive(true);
        
        PlayOnClick();
    }

    public void ExitGame()
    {
        PlayOnClick();
        
        Application.Quit();
    }

    public void OpenHelpMenu()
    {
        mainMenu.SetActive(false);
        helpMenu.SetActive(true);
        
        PlayOnClick();
    }

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        helpMenu.SetActive(false);
        
        PlayOnClick();
    }

    public void UpdateSliderValue(float value)
    {
        sliderValueText.text = value.ToString("0");
        sliderValue = value;
    }

    public void UpdateOptionValue(int value)
    {
        optionValue = value switch
        {
            0 => "Option A",
            1 => "Option B",
            2 => "Option C",
            3 => "Option D",
            4 => "Option E",
            _ => optionValue
        };
        
        PlayOnClick();
    }

    public void Apply()
    {
        if (deleteToggle.isOn)
        {
            foreach (Transform item in content.transform)
            {
                Destroy(item.gameObject);
            }
        }
        else if (changeToggle.isOn)
        {
            foreach (Transform itemTransform in content.transform)
            {
                itemTransform.Find("Option").GetComponent<TextMeshProUGUI>().text = "Option B";
            }
        }
        
        PlayOnClick();
    }

    public void SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
        Transform itemTransform = item.transform;

        itemTransform.Find("Number").GetComponent<TextMeshProUGUI>().text = sliderValue.ToString("0");
        itemTransform.Find("Option").GetComponent<TextMeshProUGUI>().text = optionValue;
        
        itemTransform.SetParent(content.transform);
        item.GetComponent<RectTransform>().localScale = Vector3.one;

        PlayOnClick();
    }
    
    public void PlayOnClick()
    {
        AkSoundEngine.PostEvent("sfx_ui_button_onClick", gameObject);
    }
}
