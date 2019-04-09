using UnityEngine;
using UnityEngine.UI;

namespace UniRemocon
{
	public class DemoScene : MonoBehaviour
	{
		public Text m_textUI;

		private void Update()
		{
			m_textUI.text = $"Time Scale: {Time.timeScale.ToString()}";
		}
	}
}