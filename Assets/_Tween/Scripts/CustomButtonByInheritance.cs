using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Tween
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(AudioSource))]
    public class CustomButtonByInheritance : Button
    {
        public static string AnimationTypeName => nameof(_animationButtonType);
        public static string CurveEaseName => nameof(_curveEase);
        public static string DurationName => nameof(_duration);
        public static string IndependentUpdateName => nameof(_isIndependentUpdate);

        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private AnimationButtonType _animationButtonType = AnimationButtonType.ChangePosition;
        [SerializeField] private Ease _curveEase = Ease.Linear;
        [SerializeField] private float _duration = 0.6f;
        [SerializeField] private float _strength = 30f;
        [SerializeField] private bool _isIndependentUpdate = true;

        private Tweener _tweenAnimation;

        protected override void Awake()
        {
            base.Awake();
            InitRectTransform();
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            InitRectTransform();
        }

        private void InitRectTransform() =>
            _rectTransform ??= GetComponent<RectTransform>();


        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            ActivateAnimation();
        }

        private void ActivateAnimation()
        {
            StopAnimation();

            switch (_animationButtonType)
            {
                case AnimationButtonType.ChangeRotation:
                    _rectTransform.DOShakeRotation(_duration, Vector3.forward * _strength).SetEase(_curveEase).SetUpdate(_isIndependentUpdate);
                    break;

                case AnimationButtonType.ChangePosition:
                    _rectTransform.DOShakeAnchorPos(_duration, Vector2.one * _strength).SetEase(_curveEase).SetUpdate(_isIndependentUpdate);
                    break;
            }
        }

        [ContextMenu(nameof(StopAnimation))]
        private void StopAnimation() =>
            _tweenAnimation.Kill();

        private void ActivateSound()
        {
            _audioSource.Play();
        }
    }
}
