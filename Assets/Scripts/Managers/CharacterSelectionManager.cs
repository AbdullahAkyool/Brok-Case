using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private GameObject selectionPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private List<SelectableCharacterCard> characterCards;

    private SelectableCharacterCard selectedCard;

    public CharacterDataSO SelectedCharacterData { get; private set; }

    private void Awake()
    {
        foreach (var card in characterCards)
        {
            card.OnSelected += OnCharacterSelected;
        }

        playButton.onClick.AddListener(OnPlayClicked);

        OpenSelectionPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenSelectionPanel();
        }
    }

    private void OnCharacterSelected(SelectableCharacterCard selected)
    {
        if (selectedCard != null) selectedCard.SetScaleNormal();

        foreach (var card in characterCards)
        {
            card.IsSelected = false;
            card.SetScaleNormal();
        }

        selectedCard = selected;

        if (selectedCard.IsSelected)
        {
            selectedCard.IsSelected = false;
            selectedCard.SetScaleNormal();
            selectedCard = null;
            SelectedCharacterData = null;
            return;
        }

        selectedCard.IsSelected = true;
        SelectedCharacterData = selected.GetCharacterData();
        selectedCard.SetScaleSelected();
    }

    private void OnPlayClicked()
    {
        if (SelectedCharacterData == null)
        {
            Debug.LogWarning("Karakter seçilmedi!");
            return;
        }

        CloseSelectionPanel();

        SpawnManager.Instance.SpawnCharacter(SelectedCharacterData);
    }

    public void OpenSelectionPanel()
    {
        Time.timeScale = 0f;
        selectionPanel.SetActive(true);

        if (selectedCard)
        {
            selectedCard.IsSelected = false;
            selectedCard.SetScaleNormal();
            selectedCard = null;
            SelectedCharacterData = null;
        }

        foreach (var card in characterCards)
        {
            card.SetCard();
        }
    }

    public void CloseSelectionPanel()
    {
        Time.timeScale = 1f;
        selectionPanel.SetActive(false);
    }
}
