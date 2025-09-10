using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class sahnegecis : MonoBehaviour
{
    public GameObject yuklenir;

    void Start()
    {
        yuklenir.SetActive(false);
    }

    // Başqa səhnəyə keçid
    public void GoToSceneByIndex(int index)
    {
        yuklenir.SetActive(true);
        SceneManager.LoadScene(index);
    }

    // Aktiv səhnəni yeniləmək
    public void ReloadActiveScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadSceneAsync(currentSceneIndex));
    }

    // Coroutine ilə səhnə yükləmək
    IEnumerator LoadSceneAsync(int index)
    {
        yuklenir.SetActive(true);  // loading ekranını göstər

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        {
            // Burada loading bar varsa update edə bilərsən
            yield return null;
        }

        yuklenir.SetActive(false); // səhnə yükləndikdən sonra gizlət
    }
}
