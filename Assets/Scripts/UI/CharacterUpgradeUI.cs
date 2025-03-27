using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CharacterUpgradeUI : MonoBehaviour
{
    public static CharacterUpgradeUI Instance { get; private set; }

    [SerializeField] private Button walkButton;
    [SerializeField] private Button runButton;
    [SerializeField] private Button jumpButton;

    [SerializeField] private TMP_Text walkText;
    [SerializeField] private TMP_Text runText;
    [SerializeField] private TMP_Text jumpText;

    [Inject] private SaveSystem _saveSystem;

    private CharacterDataSO currentCharacter;

    void Awake()
    {
        Instance = this;
    }

    private void UpdateTexts()
    {
        walkText.text = $"Walk: {currentCharacter.walkSpeed}";
        runText.text = $"Run: {currentCharacter.runSpeed}";
        jumpText.text = $"Jump: {currentCharacter.jumpPower}";
    }

    public void UpgradeCharacter(CharacterDataSO targetCharacterData)
    {
        currentCharacter = targetCharacterData;
        
        walkButton.onClick.RemoveAllListeners();
        runButton.onClick.RemoveAllListeners();
        jumpButton.onClick.RemoveAllListeners();
        
        walkButton.onClick.AddListener(() =>
        {
            currentCharacter.walkSpeed += 0.5f;
            UpdateTexts();
            _saveSystem.Save(currentCharacter);
        });

        runButton.onClick.AddListener(() =>
        {
            currentCharacter.runSpeed += 0.5f;
            UpdateTexts();
            _saveSystem.Save(currentCharacter);
        });

        jumpButton.onClick.AddListener(() =>
        {
            currentCharacter.jumpPower += 0.5f;
            UpdateTexts();
            _saveSystem.Save(currentCharacter);
        });

        UpdateTexts();
    }
}
