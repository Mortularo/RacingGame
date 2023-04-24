using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Profile
{
    [CreateAssetMenu(fileName = nameof(ProfileSettingsManager),
        menuName = "Configs/" + nameof(ProfileSettingsManager))]
    internal class ProfileSettingsManager : ScriptableObject
    {
        [field: SerializeField] public GameState gameState { get; private set; }
        [field: SerializeField] public float CarSpeed { get; private set; }
        [field: SerializeField] public float CarJumpForce { get; private set; }
    }
}
