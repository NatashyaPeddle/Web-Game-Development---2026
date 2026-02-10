using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuInput : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private bool isMenuOpen;
    [SerializeField] private Slider mouseSensibilitySliider;
   
    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;

        mouseSensibilitySliider.onValueChanged.AddListener(delegate { OnValueChangedRuntime(mouseSensibilitySliider.value); });

    }

    private void OnDisable()
    {
       openMenu.started -= ToggleMenu;

        mouseSensibilitySliider.onValueChanged.RemoveListener(delegate { OnValueChangedRuntime(mouseSensibilitySliider.value); });
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        Debug.Log("open menu called pressing p");

        isMenuOpen =! isMenuOpen;


        menuPanel.SetActive(isMenuOpen);

        if (isMenuOpen)
        {

            GetComponent<PlayerInput>().enabled = false; ///disable the component

            InputSystem.actions.FindActionMap("Player").Disable(); //disable the action map for player

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else{

            GetComponent<PlayerInput>().enabled = true; 

            InputSystem.actions.FindActionMap("Player").Enable(); 

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

    
    }

    private void OnValueChangedRuntime(float value)
    {
        Debug.Log($"menuInput Value changed - {value}");
    }


}
