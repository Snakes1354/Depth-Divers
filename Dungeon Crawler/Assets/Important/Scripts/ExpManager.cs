using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{

    public static ExpManager Instance;
    // I used a static so that my ExpManager can be accessed from other scripts.

    [Header("Experience")]
    [SerializeField] AnimationCurve experienceCurve;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceFill;
    [SerializeField] Slider experienceSlider;

    // VARIABLES 

    public int currentLevel;
    public int totalExperience;
    public int previousLevelsExperience;
    public int nextLevelsExperience;

    private void Start()
    {
        UpdateLevel(); // Calleds the updatelevel method
        StatsUI.Points -= 3; // Calls my other script called statsui and takes 3 points away
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount; // adds totalexperience + amount
        CheckForLevelUp(); // Calls checkforlevelup method
        UpdateInterface(); // calls updateinterface method
    }

    public void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelsExperience) // This if statement is used to see if I have enough experience to level up
        {
            currentLevel++; // Makes my level + 1
            UpdateLevel(); // This calls the updatelevel method
        }
    }

    public void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel); // This and the next line is to make it when I level up it makes it need more experience
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel + 1);
        StatsUI.Points += 3; // Adds 3 more points to my statui
        UpdateInterface(); // Calls the updateinterface method
    }

    public void UpdateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

       LevelText.text = currentLevel.ToString(); // Updates my level on my ui
       experienceText.text = start + " exp / " + end + " exp"; // Updates the exp needed for the next level
       experienceSlider.maxValue = end;
       experienceSlider.value = start;
    }
    
    private void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject); // Destroys gameobject
        // This is used to make sure there is only one expManager in my game
    }
}