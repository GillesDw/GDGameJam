using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] GameObject endGameScreen, gameOverScreen;
    [SerializeField] GameObject exitButton, restartButton;

    [SerializeField] AudioSource ambienceSrc, clothSrc, footstepsSrc, breathSrc, flashlightSrc, throwableItem, blindedEnemySrc, bearEnemySrc, stalkerSrc, coughSrc, enemiesFootstepSrc;
    //[SerializeField] List<AudioClip> ambienceClip, clothClip, breathClip,footstepsClip, flashlightClip, throwableItemClip, coughClip, thrillClip, stalkerWhispersClip, bearScreamClip, blindedScreamClip;

    private void Start()
    {
        endGameScreen.SetActive(false);
        instance = this;
    }

    public void EndOfTheGame()
    {
        PlayerMovementTutorial.playerMovementEnabled = false;
        PlayerMovementTutorial.playerRotationEnabled = false;
        endGameScreen.SetActive(true);
        exitButton.SetActive(true);
        restartButton.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameOver()
    {
        PlayerMovementTutorial.playerMovementEnabled = false;
        PlayerMovementTutorial.playerRotationEnabled = false;
        gameOverScreen.SetActive(true);
        exitButton.SetActive(true);
        restartButton.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerMovementTutorial.playerMovementEnabled = true;
        PlayerMovementTutorial.playerRotationEnabled = true;
    }
}
