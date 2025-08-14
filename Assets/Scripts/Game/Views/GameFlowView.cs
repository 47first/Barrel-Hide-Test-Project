using BarrelHide.Game.Consts;
using BarrelHide.Game.Views.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace BarrelHide.Game.Views
{
    public class GameFlowView : MonoBehaviour
    {
        [Header(HeaderConst.References)]
        [SerializeField] private Animator _animator;
        [SerializeField] private TextMeshProUGUI _topBarLabel;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Slider _timerSlider;

        public void AddResetButtonClickCallback(UnityAction callback)
        {
            _restartButton.onClick.AddListener(callback);
        }

        public void RemoveButtonClickCallback(UnityAction callback)
        {
            _restartButton.onClick.RemoveListener(callback);
        }

        public void SetTopBarText(string text)
        {
            _topBarLabel.text = text;
        }

        public void SetTimeSliderValue(float value)
        {
            _timerSlider.value = value;
        }

        public void SetState(GameFlowViewState state)
        {
            _animator.SetInteger(AnimatorHashConst.State, (int)state);
        }
    }
}
