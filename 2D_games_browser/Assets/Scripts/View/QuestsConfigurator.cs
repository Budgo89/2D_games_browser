using Assets.Scripts.Quests;
using UnityEngine;

namespace Assets.Scripts.View
{
    public class QuestsConfigurator : MonoBehaviour
    {
        [SerializeField] private QuestObjectView _singleQuestView;
        private Quest _singleQuest;

        #region Unity methods

        private void Start()
        {
            _singleQuest = new Quest(_singleQuestView, new SwitchQuestModel());
            _singleQuest.Reset();
        }

        private void OnDestroy()
        {
            _singleQuest.Dispose();
        }

        #endregion
    }
}
