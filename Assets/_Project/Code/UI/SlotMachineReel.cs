using AxGrid.Base;
using DG.Tweening;
using System.Threading.Tasks;
using TestProject.Extensions;
using UnityEngine;
using YamlDotNet.Core.Tokens;

namespace TestProject.UI
{
    public class SlotMachineReel : MonoBehaviourExt
    {
        private const float DEFAULT_ROLL_SPEED = 0.25f;

        [SerializeField] private SlotMachineItem[] _items;
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _minAnchoredPosY;
        private float _rollSpeed = DEFAULT_ROLL_SPEED;
        private RectTransform _rectTransform;
        private Vector2 _startPosition;
        private bool _isRolling;
        private Tween _speedUpTween;
        private Tween _rollingTween;

        [OnAwake]
        private void Initialize()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPosition = _rectTransform.anchoredPosition;
        }

        public void Roll(float delay, float speed = DEFAULT_ROLL_SPEED)
        {
            if (_isRolling)
                return;

            _rollSpeed = speed < 0.01f ? DEFAULT_ROLL_SPEED : speed;
            _isRolling = true;
            _speedUpTween = _rectTransform.DOAnchorPosY(_minAnchoredPosY, _rollSpeed * 2f).SetEase(_curve).SetDelay(delay);
            _speedUpTween.onComplete += OnSpeedUpComplete;
                /*OnComplete(OnSpeedUpComplete);*/
        }

        private void OnSpeedUpComplete()
        {
            KillTween(ref _speedUpTween, false);

            BlurIcons(true);

            _rollingTween = DOTween.Sequence(this).
                Append(_rectTransform.DOAnchorPosY(0f, 0f)).
                Append(_rectTransform.DOAnchorPosY(_minAnchoredPosY, _rollSpeed).
                SetEase(Ease.Linear)).SetLoops(-1);

            _rollingTween.OnStepComplete(MoveBottomItems);
            _rollingTween.OnStart(MoveBottomItems);
        }

        public async Task Stop(float speed)
        {
            if (!_isRolling)
                return;

            _isRolling = false;
            await KillTweenWaitingLastLoop(_speedUpTween, true, false, speed);
            await KillTweenWaitingLastLoop(_rollingTween, true, false, speed);

            BlurIcons(false);
        }

        private async Task KillTweenWaitingLastLoop(Tween tween, bool resetToDefaultPosition, bool forceKill = true, float elapsedTime = 0f)
        {
            if (tween == null) return;

            if (!forceKill)
            {
                tween.timeScale = elapsedTime;
                int waitingLoops = tween.hasLoops ? tween.CompletedLoops() + 1 : tween.CompletedLoops();
                await tween.AsyncWaitForElapsedLoops(waitingLoops);
            }

            KillTween(ref tween, resetToDefaultPosition);
        }

        private void KillTween(ref Tween tween, bool resetToDefaultPosition)
        {
            if (tween == null) return;

            if (resetToDefaultPosition && _rectTransform.anchoredPosition != _startPosition)
                _rectTransform.anchoredPosition = _startPosition;
            
            tween.Kill();
            tween = null;
        }



        private void MoveBottomItems()
        {
            _rectTransform.GetChild(_rectTransform.childCount - 1).SetAsFirstSibling();
            _rectTransform.GetChild(_rectTransform.childCount - 1).SetAsFirstSibling();
        }

        private void BlurIcons(bool keepBlurred)
        {
            foreach (var item in _items)
            {
                item.Animate(keepBlurred);
            }
        }

        public void ShuffleIcons()
        {
            transform.ShuffleChildrens();
        }
    }
}
