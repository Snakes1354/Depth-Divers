using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{

    public static ExpManager Instance;

    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    public int currentLevel;
    public int totalExperience;
    public int previousLevelsExperience;
    public int nextLevelsExperience;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceFill;
    [SerializeField] Slider experienceSlider;

    private void Start()
    {
        UpdateLevel();
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    public void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            UpdateLevel();
        }
    }

    public void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    public void UpdateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

       LevelText.text = currentLevel.ToString();
       experienceText.text = start + " exp / " + end + " exp";
       experienceSlider.maxValue = end;
       experienceSlider.value = start;
    }
    
    private void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject);
    }


}
