using System;
using UniRemocon.Internal;
using UnityEngine;
using UnityEngine.UI;

namespace UniRemocon
{
	/// <summary>
	/// リモコンの UI を管理するクラス
	/// </summary>
	[DisallowMultipleComponent]
	public sealed class UniRemoconUI : MonoBehaviour
	{
		//==============================================================================
		// 定数
		//==============================================================================
		private static readonly float[] TIME_SCALE_LIST =
		{
			0		,
			0.25f	,
			0.5f	,
			1		,
			2		,
			4		,
			8		,
			16		,
			32		,
			64		,
		};

		//==============================================================================
		// 変数(SerializeField)
		//==============================================================================
		[SerializeField] private GameObject			m_openBaseUI		= null;
		[SerializeField] private Button				m_openButtonUI		= null;
		[SerializeField] private Text[]				m_speedTextUIList	= null;
		[SerializeField] private SelectButtonUI[]	m_speedButtonUIList	= null;

		//==============================================================================
		// 変数(readonly)
		//==============================================================================
		private bool	m_isOpen		;
		private int		m_selectedIndex	;

		//==============================================================================
		// 関数
		//==============================================================================
		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			m_openButtonUI.onClick.AddListener( () => OnChangeSelectedIsOpen( !m_isOpen ) );

			for ( int i = 0; i < m_speedButtonUIList.Length; i++ )
			{
				var buttonUI = m_speedButtonUIList[ i ];
				var key = i;
				buttonUI.mReleased = () => OnChangeSelectedSpeedIndex( key );
			}

			var index = Array.FindIndex( TIME_SCALE_LIST, c => c == Time.timeScale );
			index = index != -1 ? index : 3;
			m_selectedIndex = index;

			OnChangeSelectedIsOpen( m_isOpen );
			OnChangeSelectedSpeedIndex( m_selectedIndex );
		}

		/// <summary>
		/// 選択中のスピードのインデックスが変更された
		/// </summary>
		private void OnChangeSelectedSpeedIndex( int index )
		{
			m_selectedIndex = index;

			for ( int i = 0; i < m_speedButtonUIList.Length; i++ )
			{
				var buttonUI = m_speedButtonUIList[ i ];
				buttonUI.SetIsSelected( m_selectedIndex == i );
			}

			var timeScale = TIME_SCALE_LIST[ m_selectedIndex ];

			Time.timeScale = timeScale;

			var text = timeScale.ToString( "0.##" );

			foreach ( var n in m_speedTextUIList )
			{
				n.text = text;
			}
		}

		/// <summary>
		/// 選択中の開いているかどうかが変更された
		/// </summary>
		private void OnChangeSelectedIsOpen( bool isOpen )
		{
			m_isOpen = isOpen;
			m_openBaseUI.SetActive( isOpen );
		}
	}
}