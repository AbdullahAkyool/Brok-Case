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

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void UpdateTexts(CharacterDataSO targetCharacterData)
    {
        walkText.text = $"Walk: {targetCharacterData.walkSpeed}";
        runText.text = $"Run: {targetCharacterData.runSpeed}";
        jumpText.text = $"Jump: {targetCharacterData.jumpPower}";
    }

    public void UpgradeCharacter(CharacterDataSO targetCharacterData)
    {
        UpdateTexts(targetCharacterData);

        walkButton.onClick.AddListener(() =>
        {
            targetCharacterData.walkSpeed += 0.5f;
            UpdateTexts(targetCharacterData);
        });

        runButton.onClick.AddListener(() =>
        {
            targetCharacterData.runSpeed += 0.5f;
            UpdateTexts(targetCharacterData);
        });

        jumpButton.onClick.AddListener(() =>
        {
            targetCharacterData.jumpPower += 0.5f;
            UpdateTexts(targetCharacterData);
        });
    }
}
