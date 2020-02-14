using Deirin.EB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : BaseBehaviour
{
	public enum ElementType { Fire, Ice, Thunder }

	public abstract ElementType GetElementType();
}
