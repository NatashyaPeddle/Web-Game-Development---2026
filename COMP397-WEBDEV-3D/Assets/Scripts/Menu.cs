using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : PersistentSingleton<Menu>
{
    ///[SerializeField] 

    //public void StartPlayGameAdditive()
    //{
    //    SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

    //}
    //public void StartPlayGameSingle()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //}


    [SerializeField] private Button saveBtn;
    [SerializeField] private Button loadBtn;

    private void Start()
    {
        saveBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.gameData.fileName = "Menu";
            SaveLoadSystem.Instance.gameData.sceneName = "SampleScene";
            SaveLoadSystem.Instance.SaveGame();
        });

        loadBtn.onClick.AddListener(() =>
        {
            SaveLoadSystem.Instance.LoadGame("Menu");

        });


    }

}
