using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStoppable 
{
	bool Stopped { get; }

	void Stop(bool callEvent = true);

}
