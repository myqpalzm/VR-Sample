using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartupManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> LoadingBoxes;
    
    private void Start()
    {
        StartCoroutine(StartSplashScreen());
    }

    private IEnumerator StartSplashScreen()
    {
        foreach (GameObject box in LoadingBoxes)
        {
            box.SetActive(false);
        }
        
        int i = 0;
        
        foreach (GameObject box in LoadingBoxes)
        {
            box.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
        
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
