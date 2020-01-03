
using UnityEngine;
using UnityEngine.SceneManagement;
public class TutorialManager : MonoBehaviour
{
    public GameObject[] textObjects;
    private int currentIndex;
    private int totalObjects;
    
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.AudioManager.m_instance.PlayMusic("BG_3");
        totalObjects = textObjects.Length;
        currentIndex = 0;
    }

    public void ShowTutorial()
    {
        if (currentIndex > totalObjects - 1)
            currentIndex = totalObjects - 1;
        else if (currentIndex < 0)
            currentIndex = 0;

        textObjects[currentIndex].SetActive(true);
    }

    public void Forward()
    {
        textObjects[currentIndex].SetActive(false);
        if (currentIndex + 1 > totalObjects)
            currentIndex = totalObjects - 1;
        else
            currentIndex++;
        ShowTutorial();
    }

    public void Backward()
    {
        textObjects[currentIndex].SetActive(false);
        if (currentIndex - 1 < 0)
            currentIndex = 0;
        else
            currentIndex--;
        ShowTutorial();
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
