using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    private void OnEnable()
    {
        UIDocument ui = FindObjectOfType<UIDocument>();
        VisualElement root = ui.rootVisualElement;

        Button randomNumberBtn = root.Q<Button>("RandoNumberButton");
        Button randomArrayBtn = root.Q<Button>("RandoArrayButton");
        Button randomLadderBtn = root.Q<Button>("RandoLadderButton");

        randomNumberBtn.RegisterCallback<ClickEvent>((e) => 
        { SceneManager.LoadScene("Number"); });
        randomArrayBtn.RegisterCallback<ClickEvent>((e) => 
        { SceneManager.LoadScene("Array"); });
        randomLadderBtn.RegisterCallback<ClickEvent>((e) => 
        { SceneManager.LoadScene("Ladder"); });
    }
}
