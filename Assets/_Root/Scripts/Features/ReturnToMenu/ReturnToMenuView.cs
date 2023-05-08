using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Features.ReturnToMenu
{
    internal class ReturnToMenuView : MonoBehaviour
    {
        [SerializeField] private Button _returnToMenuButton;

        public void Init(UnityAction openMenu) =>
            _returnToMenuButton.onClick.AddListener(openMenu);
        
        public void OnDestroy() =>
            _returnToMenuButton.onClick.RemoveAllListeners();
    }
}
