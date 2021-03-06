﻿using UnityEngine;
using System.Collections;
using strange.extensions.context.impl;

public class DeviceAuthenticationContext :  SignalContext{

	public DeviceAuthenticationContext(ContextView contextView) : base(contextView)
  {
  }

  protected override void mapBindings()
  {
    //Binding DeviceAuthenticationMediator to DeviceAuthenticationView
    mediationBinder.Bind<DeviceAuthenticationView>().To<DeviceAuthenticationMediator>();
    commandBinder.Bind<ChangeUserNameSignal>().To<ChangeUserNameCommand>();
  }
}
