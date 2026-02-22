using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    ///[SerializeField] 

    public void StartPlayGameAdditive()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

    }
    public void StartPlayGameSingle()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
