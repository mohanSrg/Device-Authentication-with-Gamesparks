using UnityEngine;
using System.Collections;
using GameSparks.Platforms;
using GameSparks.Core;
using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using UnityEngine.UI;

public class DeviceAuthenticationView : View {

  // Use this for initialization
  public GameObject UserNamePopup;
  public InputField UserName;
  public Text nameFromServer;
  public Signal<PoPUpType> ClickSignal;

  public void Initialize()
  {
    ClickSignal = new Signal<PoPUpType>();
  }

  public void OnOkClick()
  {
    ClickSignal.Dispatch(PoPUpType.Ok);
  }

  public void OnCancelClick()
  {
    ClickSignal.Dispatch(PoPUpType.Cancel);
  }

}
