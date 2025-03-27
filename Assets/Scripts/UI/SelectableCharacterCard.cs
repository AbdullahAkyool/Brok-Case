using System;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SelectableCharacterCard : MonoBehaviour
{
    [SerializeField] private CharacterDataSO characterData;
    [SerializeField] private TMP_Text CharacterNameText;
    [SerializeField] private TMP_Text walkText;
    [SerializeField] private TMP_Text runText;
    [SerializeField] private TMP_Text jumpText;
    [SerializeField] private UnityEngine.UI.Image characterIconImage;
    [SerializeField] private Button selectButton;

    public Action<SelectableCharacterCard> OnSelected;

    private Vector3 normalScale;
    private Vector3 selectedScale;

    [SerializeField] private bool isSelected;
    public bool IsSelected { get => isSelected; set => isSelected = value; }

    private void Awake()
    {
        normalScale = transform.localScale;
        selectedScale = normalScale * 1.1f;

        selectButton.onClick.AddListener(() => OnSelected?.Invoke(this));
    }

    public void SetCard()
    {
        CharacterNameText.text = characterData.characterId;
        walkText.text = $"Walk: {characterData.walkSpeed}";
        runText.text = $"Run: {characterData.runSpeed}";
        jumpText.text = $"Jump: {characterData.jumpPower}";
        characterIconImage.sprite = characterData.characterIcon;
    }

    public CharacterDataSO GetCharacterData() => characterData;

    public void SetScaleSelected() => transform.localScale = selectedScale;
    public void SetScaleNormal() => transform.localScale = normalScale;
}

