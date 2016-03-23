using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

  public class DeviceAuthenticationBootstrap : ContextView{

	  // Use this for initialization
    private	void Awake () {
      context = new DeviceAuthenticationContext(this);
	  }

  }
