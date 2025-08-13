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

        public void SetResetButtonClickCallback(UnityAction callback)
        {
            _restartButton.onClick.AddListener(callback);
        }

        public void RemoveButtonClickCallback(UnityAction callback)
        {
            _restartButton.onClick.RemoveListener(callback);
        }

        public void SetBestTime(float value)
        {
            _topBarLabel.text = $"{value} s.";
        }

        public void SetTime(float value)
        {
            _timerSlider.value = value;
        }

        public void SetState(GameFlowViewState state)
        {
            _topBarLabel.text = state switch
            {
                GameFlowViewState.Won => "Won",
                GameFlowViewState.Lose => "Lose",
                _ => string.Empty
            };

            _animator.SetInteger(AnimatorHashConst.State, (int)state);
        }
    }
}
