using System;
using UnityEngine;
using UnityEngine.UI;

namespace UniRemocon.Internal
{
	[DisallowMultipleComponent]
	[RequireComponent( typeof( Button ), typeof( Image ) )]
	public sealed class SelectButtonUI : MonoBehaviour
	{
		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private Button	m_buttonUI	= null;
		[SerializeField] private Text	m_textUI	= null;
		[SerializeField] private Image	m_imageUI	= null;

		//==============================================================================
		// イベント
		//==============================================================================
		public Action mReleased
		{
			set
			{
				m_buttonUI.onClick.RemoveAllListeners();
				m_buttonUI.onClick.AddListener( () => value?.Invoke() );
			}
		}

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 選択されているかどうかを設定します
		/// </summary>
		public void SetIsSelected( bool isSelected )
		{
			m_imageUI.color = isSelected ? Color.yellow : Color.white;
		}

		/// <summary>
		/// テキストを設定します
		/// </summary>
		public void SetText( string text )
		{
			m_textUI.text = text;
		}
	}
}