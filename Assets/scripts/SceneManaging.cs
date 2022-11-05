using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManaging : MonoBehaviour
{
    public void NextScene() // Sýradaki sahne metodu
    {
        Time.timeScale = 1.0f;  //Oyunu devam ettiren kod
        SceneManager.LoadScene(1);  // Istedigimiz sahneyi yükleyen kod
    }
    public void Restart()  //Yeniden basla metodu
    {
        Time.timeScale = 1.0f; 
        SceneManager.LoadScene(1);
    }
    public void ReturnToMainMenu()  //Menuye donme metodu
    {
        SceneManager.LoadScene(0);
    }
}
