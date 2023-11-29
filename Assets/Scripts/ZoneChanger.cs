using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneChanger : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndex;

    public void ChangeZonee()
    {
        SceneManager.LoadScene(sceneBuildIndex + 1);
    }

    public void ReturnZonaM()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void ReturnCentroCo()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void ReturnZonaAlta()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void MagicalReal()
    {
        SceneManager.LoadSceneAsync(5);
    }
}
