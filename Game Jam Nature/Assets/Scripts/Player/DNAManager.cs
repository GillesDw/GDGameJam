using System.Collections.Generic;
using UnityEngine;

public class DNAManager : MonoBehaviour
{
    public static int currentDnaCount = 0;
    [SerializeField] List<GameObject> dnaImg, dnaImgEndScreen;

    public static void AddDNACount()
    {
        currentDnaCount++;
        Debug.Log("dna");
    }

    private void Start()
    {
        dnaImg[0].SetActive(false);
        dnaImg[1].SetActive(false);
        dnaImg[2].SetActive(false);
        dnaImgEndScreen[0].SetActive(false);
        dnaImgEndScreen[1].SetActive(false);
        dnaImgEndScreen[2].SetActive(false);
    }

    private void Update()
    {
        if(currentDnaCount <= 0) {
            for (int i = 0; i < dnaImg.Count; i++)
            {
                dnaImg[i].SetActive(false);
            }
        }
        if(currentDnaCount == 1) {
            dnaImg[0].SetActive(true);
            dnaImg[1].SetActive(false);
            dnaImg[2].SetActive(false);
            dnaImgEndScreen[0].SetActive(true);
            dnaImgEndScreen[1].SetActive(false);
            dnaImgEndScreen[2].SetActive(false);
        }
        if (currentDnaCount == 2)
        {
            dnaImg[0].SetActive(true);
            dnaImg[1].SetActive(true);
            dnaImg[2].SetActive(false);
            dnaImgEndScreen[0].SetActive(true);
            dnaImgEndScreen[1].SetActive(true);
            dnaImgEndScreen[2].SetActive(false);

        }
        if (currentDnaCount == 3)
        {
            dnaImg[0].SetActive(true);
            dnaImg[1].SetActive(true);
            dnaImg[2].SetActive(true);
            dnaImgEndScreen[0].SetActive(true);
            dnaImgEndScreen[1].SetActive(true);
            dnaImgEndScreen[2].SetActive(true);

            //Sound of achievement
        }
    }
}
