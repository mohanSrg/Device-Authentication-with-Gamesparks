using UnityEngine;
using System.Collections;
using strange.extensions.command.impl;


public class ChangeUserNameCommand : Command {

  [Inject]
  public string UserName { get; set; }

  
  public override void Execute()
  {
    new GameSparks.Api.Requests.ChangeUserDetailsRequest().SetDisplayName(UserName).Send((response) =>
    {
      if(!response.HasErrors)
      {
        Debug.Log(response);
        Debug.Log("Successfully updated username in Server...");
        
      }
      else
      {
        Debug.Log(response);
        Debug.Log("Failed to updated username in Server");
      }
    });
  }
}
