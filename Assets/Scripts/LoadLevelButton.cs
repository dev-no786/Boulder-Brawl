using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelButton : MonoBehaviour
{
    private Button loadLevelButton;
    // Start is called before the first frame update
    void Start()
    {
        loadLevelButton = GetComponent<Button>();
        loadLevelButton.onClick.AddListener(LoadLevel);
    }

    // Update is called once per frame
    void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
