using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;
    [SerializeField] Canvas inGameUI;
    public bool canPause;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        inGameUI.enabled = true;
        canPause = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && canPause)
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                pauseMenu.enabled = true;
                inGameUI.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                pauseMenu.enabled = false;
                inGameUI.enabled = true;
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.enabled = false;
        inGameUI.enabled = true;
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
