using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FilterChangeButton : MonoBehaviour
{
    public Button homeBtn;
    public Button catHelmetBtn;
    public Button catHelmetBtn2;
    public Button petsBtn;
    public Button petsBtn2;
    public Button hatsBtn;
    public Button hatsBtn2;
    public Button waterBalloonBtn;
    public Button waterBalloonBtn2;
    public Button aingBtn;
    public Button aingBtn2;
    public Button glassessBtn;
    public Button glassessBtn2;
    public Button astronautBtn;
    public Button astronautBtn2;
    public Button orangeMushroomBtn;
    public Button orangeMushroomBtn2;
    public Button pinkBeanBtn;
    public Button pinkBeanBtn2;
    public Button friedAingBtn;
    public Button friedAingBtn2;
    public Button codyBtn;
    public Button codyBtn2;
    void Awake()
    {
        homeBtn.onClick.AddListener(homeFilter);
        catHelmetBtn.onClick.AddListener(catHelmetFilter);
        catHelmetBtn2.onClick.AddListener(catHelmetFilter);
        petsBtn.onClick.AddListener(petsFilter);
        petsBtn2.onClick.AddListener(petsFilter);
        hatsBtn.onClick.AddListener(hatsFilter);
        hatsBtn2.onClick.AddListener(hatsFilter);
        waterBalloonBtn.onClick.AddListener(waterBalloonFilter);
        waterBalloonBtn2.onClick.AddListener(waterBalloonFilter);
        aingBtn.onClick.AddListener(aingFilter);
        aingBtn2.onClick.AddListener(aingFilter);
        glassessBtn.onClick.AddListener(glassessFilter);
        glassessBtn2.onClick.AddListener(glassessFilter);
        astronautBtn.onClick.AddListener(astronautFilter);
        astronautBtn2.onClick.AddListener(astronautFilter);
        orangeMushroomBtn.onClick.AddListener(orangeMushroomFilter);
        orangeMushroomBtn2.onClick.AddListener(orangeMushroomFilter);
        pinkBeanBtn.onClick.AddListener(pinkBeanFilter);
        pinkBeanBtn2.onClick.AddListener(pinkBeanFilter);
        friedAingBtn.onClick.AddListener(friedAingFilter);
        friedAingBtn2.onClick.AddListener(friedAingFilter);
        codyBtn.onClick.AddListener(codyFilter);
        codyBtn2.onClick.AddListener(codyFilter);
    }
    void homeFilter()
    {
        SceneManager.LoadScene("MainScene");
    }
    void catHelmetFilter()
    {
        SceneManager.LoadScene("CatHelmetScene");
    }

    void petsFilter()
    {
        SceneManager.LoadScene("PetsScene");
    }
    void hatsFilter()
    {
        SceneManager.LoadScene("HatsScene");
    }
    void waterBalloonFilter()
    {
        SceneManager.LoadScene("WaterBalloonScene");
    }
    void aingFilter()
    {
        SceneManager.LoadScene("AingRealScene");
    }
    void glassessFilter()
    {
        SceneManager.LoadScene("GlassessScene");
    }
    void astronautFilter()
    {
        SceneManager.LoadScene("AstronautScene");
    }
    void orangeMushroomFilter()
    {
        SceneManager.LoadScene("OrangeMushroomScene");
    }
    void pinkBeanFilter()
    {
        SceneManager.LoadScene("PinkBeanScene");
    }
    void codyFilter()
    {
        SceneManager.LoadScene("CodyScene");
    }
    void friedAingFilter()
    {
        SceneManager.LoadScene("FriedAingScene");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
