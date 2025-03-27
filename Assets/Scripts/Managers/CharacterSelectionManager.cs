using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CharacterSelectionManager : MonoBehaviour
{
    [SerializeField] private SpawnManager spawnManager;

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

    void Start()
    {
        spawnManager = SpawnManager.Instance;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenSelectionPanel();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            if(CursorLockMode.Locked == Cursor.lockState)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
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

        spawnManager.SpawnCharacter(SelectedCharacterData);
    }

    public void OpenSelectionPanel()
    {
        Time.timeScale = 0f;
        selectionPanel.SetActive(true);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

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
