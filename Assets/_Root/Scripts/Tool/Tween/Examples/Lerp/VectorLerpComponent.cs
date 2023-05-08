using System;
using System.Collections;
using UnityEngine;

namespace Tool.Tween.Examples.Lerp
{
    internal enum RatioConversion
    {
        Linear,
        Quad,
        Root
    }

    internal class VectorLerpComponent : MonoBehaviour
    {
        [SerializeField] private RatioConversion _ratioConversion;
        [SerializeField, Min(0)] private float _duration;
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _endPoint;

        private Coroutine _coroutine;


        public void Play(Vector3 startPosition, Vector3 endPosition, float duration)
        {
            Stop();
            _coroutine = StartCoroutine(Playing(startPosition, endPosition, duration));
        }

        [ContextMenu(nameof(Play))]
        public void Play()
        {
            Vector3 startPosition = _startPoint.position;
            Vector3 endPosition = _endPoint.position;

            Play(startPosition, endPosition, _duration);
        }

        [ContextMenu(nameof(Stop))]
        public void Stop()
        {
            if (_coroutine == null)
                return;

            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        [ContextMenu(nameof(Reset))]
        public void Reset()
        {
            Stop();
            transform.position = _startPoint.position;
        }

        private IEnumerator Playing(Vector3 startPosition, Vector3 endPosition, float duration)
        {
            Transform transform = this.transform;

            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                float ratio = CalcRatio(t, duration);
                transform.position = Vector3.Lerp(startPosition, endPosition, ratio);
                yield return null;
            }
        }

        private float CalcRatio(float time, float duration)
        {
            if (duration <= 0)
                return 0;
            else
                return ConvertRatio(time / duration, _ratioConversion);
        }

        private float ConvertRatio(float ratio, RatioConversion conversion) =>
            conversion switch
            {
                RatioConversion.Linear => ratio,
                RatioConversion.Quad => Mathf.Pow(ratio, 2),
                RatioConversion.Root => Mathf.Sqrt(ratio),
                _ => throw new ArgumentOutOfRangeException(nameof(RatioConversion))
            };
    }
}
