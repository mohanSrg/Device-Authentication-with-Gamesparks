using UnityEngine;
using System.Collections;
using GameSparks.Platforms;
using GameSparks.Core;
using strange.extensions.mediation.impl;
using System;

public class DeviceAuthenticationMediator : Mediator{

  [Inject]
  public DeviceAuthenticationView DeviceAuthenticationView { get; set; }

  [Inject]
  public ChangeUserNameSignal ChangeUserNameSignal{ get; set; }
  

  public override void OnRegister()
  {
    GS.GameSparksAvailable += HandleGameSparksAvailable;
    
    DeviceAuthenticationView.Initialize();
    DeviceAuthenticationView.ClickSignal.AddListener(OnClick);
  }

  public override void OnRemove()
  {
    DeviceAuthenticationView.ClickSignal.RemoveListener(OnClick);
  }

  public void OnClick(PoPUpType type)
  {
    switch(type)
    {
      case PoPUpType.Ok:
        OnOkClick();
        break;
      case PoPUpType.Cancel:
        OnCancelClick();
        break;
    }
  }

  private void OnOkClick()
  {
    string username = DeviceAuthenticationView.UserName.text;
    ChangeUserNameSignal.Dispatch(username);
    DeviceAuthenticationView.UserNamePopup.SetActive(false);
  }

  private void OnCancelClick()
  {
    DeviceAuthenticationView.UserNamePopup.SetActive(false);
  }

  void HandleGameSparksAvailable(bool isAvailable)
  {
    if (isAvailable)
    {
      Debug.Log("GAMESPARKS AVAILABLE...");
      if (!GS.Authenticated)
      {
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
         .SetDurable(true)
          .Send((response) => {

            if (!response.HasErrors)
            {
              Debug.Log("Device Authenticated with ID => " + response.UserId);
              DeviceAuthenticationView.UserNamePopup.SetActive(true);

            }
            else
            {
              Debug.Log("Device Authentication Failed..");
            }
          });
      }
      else
      {
        Debug.Log("your device has been succesffully recognised with the server...already authenticated");
      }
    }
    else
    {
      Debug.Log("GAMESPARKS NOT AVAILABLE...");
    }
  }


}
