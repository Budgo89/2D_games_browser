using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using PlatformerMVC.View;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.View
{
    public class QuestObjectView : LevelObjectView
    {
        public int Id => _id;

        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private Text _text;

        private Color _defaultColor;
        #region Unity methods

        private void Awake()
        {
            _defaultColor = SpriteRenderer.color;
            _text.text = "Доп. задание: найдите способ добраться до сундука";
        }

        #endregion

        #region Methods

        public void ProcessComplete()
        {
            //SpriteRenderer.color = _completedColor;
            SpriteRenderer.sprite = _sprite;
            _text.text = "Доп. задание: Выполнено";
        }

        public void ProcessActivate()
        {
            SpriteRenderer.color = _defaultColor;
        }

        #endregion
    }

}
