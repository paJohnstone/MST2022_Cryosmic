using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    [SerializeField]
    public string buttonSelection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadLevel()
    {
        buttonSelection = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log("loading " + buttonSelection);
        SceneManager.LoadSceneAsync(buttonSelection);
        SceneManager.UnloadSceneAsync("LevelSelect");
    }
}
