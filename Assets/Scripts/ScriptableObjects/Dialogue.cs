using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "new dialoque")]
public class Dialogue : ScriptableObject
{
	[TextArea]public string text;
}
