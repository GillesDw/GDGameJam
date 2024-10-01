using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [SerializeField] GameObject endGameScreen, gameOverScreen;
    [SerializeField] GameObject exitButton, restartButton, noteUi, Text01, Text02;

    [SerializeField] AudioSource hideSrc, ambienceSrc, clothSrc, footstepsSrc, breathSrc, flashlightSrc, throwableItem, bearEnemySrc, stalkerSrc, coughSrc, enemiesFootstepSrc;
    [SerializeField] AudioClip[] clothClip, breathClip, footstepsClip, flashlightClip, throwableItemClip, coughClip, thrillClip, stalkerWhispersClip, bearScreamClip, blindedScreamClip;
    [SerializeField] AudioClip ambienceCaveClip, ambienceForestClip, ambienceVillageClip, doorClip;
    private void Start()
    {
        endGameScreen.SetActive(false);
        instance = this;
    }

    public void EndOfTheGame()
    {
        if (DNAManager.currentDnaCount == 3)
        {
            Text02.SetActive(true);
            Text01.SetActive(false);
        }
        else 
        {
            Text01.SetActive(true);
            Text02.SetActive(false);
        }
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

    public void AmbienceCave()
    {
        ambienceSrc.clip = ambienceCaveClip;
        ambienceSrc.Play();
    }
    public void AmbienceForest()
    {
        ambienceSrc.clip = ambienceForestClip;
        ambienceSrc.Play();
    }
    public void AmbienceVillage()
    {
        ambienceSrc.clip = ambienceVillageClip;
        ambienceSrc.Play();
    }

    public void DoorSfx()
    {
        hideSrc.clip = doorClip;
        hideSrc.Play();
    }

    public void FlashlightOn()
    {
        flashlightSrc.clip = flashlightClip[0];
        flashlightSrc.Play();
    }
    public void FlashlightOff()
    {
        flashlightSrc.clip = flashlightClip[1];
        flashlightSrc.Play();
    }
    public void FlashlightRecharge()
    {
        flashlightSrc.clip = flashlightClip[2];
        flashlightSrc.Play();
    }

    public void footstepsPlayer()
    {
        int rand = Random.Range(0, footstepsClip.Length-1);
        footstepsSrc.clip = footstepsClip[rand];
        footstepsSrc.Play();
    }

    public void ReturnButton()
    {
        noteUi.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("return button pressed");
    }

    public void CoughSFX1()
    {
        coughSrc.clip = coughClip[0];
        coughSrc.Play();
    }

    public void CoughSFX2()
    {
        coughSrc.clip = coughClip[1];
        coughSrc.Play();
    }
    public void CoughSFX3()
    {
        coughSrc.clip = coughClip[2];
        coughSrc.Play();
    }
    public void CoughSFX4()
    {
        coughSrc.clip = coughClip[3];
        coughSrc.Play();
    }
    public void CoughSFX5()
    {
        coughSrc.clip = coughClip[4];
        coughSrc.Play();
    }
}

