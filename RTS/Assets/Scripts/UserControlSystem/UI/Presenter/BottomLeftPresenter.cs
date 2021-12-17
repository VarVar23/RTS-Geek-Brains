using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomLeftPresenter : MonoBehaviour
{
    [SerializeField] private Image _sliderBackGround;
    [SerializeField] private Image _sliderFillMage;
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private SelectableValue _selectableValue;

    private bool _isSelected;

    void Start() =>
        _selectableValue.OnSelected += OnSelected;


    private void OnSelected(ISelectable selected)
    {
        _isSelected = selected != null;

        _selectedImage.enabled = _isSelected;
        _text.enabled = _isSelected;
        _healthSlider.gameObject.SetActive(_isSelected);

        if(_isSelected)
        {
            _selectedImage.sprite = selected.Icon;
            _text.text = $"{selected.Health}/{selected.MaxHealth}";
            _healthSlider.minValue = 0;
            _healthSlider.maxValue = selected.MaxHealth;
            _healthSlider.value = selected.Health;
            var color = Color.Lerp(Color.red, Color.green, selected.Health / selected.MaxHealth);
            _sliderBackGround.color = color * 0.5f;
            _sliderFillMage.color = color;
        }
    }
}
