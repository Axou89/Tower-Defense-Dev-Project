using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;
public class LobbyManager2 : MonoBehaviour
{
    private Lobby hostLobby;
    private float lobbyUpdateTimer;
    private Lobby joinedLobby;
    private float heartbeatTimer;
    private string playerName = "RandomUser" + UnityEngine.Random.Range(10, 39);
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        AuthenticationService.Instance.SignedIn += () =>
          {
              Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId);
          };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }
    private async void CreateLobby()
    {
        try
        {

            string lobbyName = "MyLobby";
            int maxPlayer = 2;
            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = false,
                Player = GetPlayer(),
                
                    Data = new Dictionary<string, DataObject> {
                { "GameMode", new DataObject(DataObject.VisibilityOptions.Public, "1V1") }
                    }
                
            };
            
            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayer,createLobbyOptions);
            hostLobby = lobby;
            joinedLobby = hostLobby;
            PrintPlayers(hostLobby);

            Debug.Log(" Created Lobby !" + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.LobbyCode);
        }
        catch(LobbyServiceException e)
        {
            Debug.Log(e);
        }  
    }
    private async void ListLobbies()
    {
        try
        {
            QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
            {
                Count = 25,
                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots,"0",QueryFilter.OpOptions.GT),
                    new QueryFilter(QueryFilter.FieldOptions.S1,"1V1",QueryFilter.OpOptions.EQ)
                },
                Order = new List<QueryOrder>
                {
                    new QueryOrder(false, QueryOrder.FieldOptions.Created)
                    
                }
            };
            QueryResponse queryreponse = await Lobbies.Instance.QueryLobbiesAsync();

            Debug.Log(queryreponse.Results);
            foreach (Lobby lobby in queryreponse.Results)
            {
                Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
            }
        }
        catch (LobbyServiceException e)

        {
            Debug.Log(e);
        }   

    }
    
    private async void UpdateLobbyGameMode(string gameMode)
    {
        try
        {
        hostLobby = await Lobbies.Instance.UpdateLobbyAsync(hostLobby.Id, new UpdateLobbyOptions
        {
            Data = new Dictionary<string, DataObject>
            {
                { "GameMode",new DataObject(DataObject.VisibilityOptions.Public,gameMode)}
            }
        });
            joinedLobby = hostLobby;
        PrintPlayers(hostLobby);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }

    } 
    private void Update()
    {
        HandleLobbyHeartbeat();
        HandleLobbyPollForUpdates();
    }
    private async void HandleLobbyHeartbeat()
    {
        if (hostLobby!=null)
        {
            heartbeatTimer -= Time.deltaTime;
            if (heartbeatTimer < 0f)
            {
                float heartbeatTimerMax = 15;
                heartbeatTimer = heartbeatTimerMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id);
            }
        }
    }
    private async void JoinLobbyByCode(string lobbyCode)
    {
        try
        {
            JoinLobbyByCodeOptions joinLobbyByCodeOptions = new JoinLobbyByCodeOptions
            {
                Player = GetPlayer()
            };
            Lobby lobby = await Lobbies.Instance.JoinLobbyByCodeAsync(lobbyCode,joinLobbyByCodeOptions);
            joinedLobby = lobby;
            Debug.Log("Joined Lobby");

            PrintPlayers(joinedLobby);
        }
        catch (LobbyServiceException e)
        {

            Debug.Log(e);    
        }

    }
    private Player GetPlayer()
    {
        return new Player
        {
            Data = new Dictionary<string, PlayerDataObject> {
                { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
            }
        };
        }
    private async void QuickJoinLobby()
    {
        await LobbyService.Instance.QuickJoinLobbyAsync();
    }

    private async void HandleLobbyPollForUpdates()
    {

        if (joinedLobby != null)
        {
            lobbyUpdateTimer -= Time.deltaTime;
            if (lobbyUpdateTimer < 0f)
            {
                float lobbyUpdateTimerMax = 1.1f ;
                lobbyUpdateTimer = lobbyUpdateTimerMax;

                Lobby lobby =   await LobbyService.Instance.GetLobbyAsync(joinedLobby.Id);
                joinedLobby = lobby;
            }
        }
    }
    private void PrintPlayers()
    {
        PrintPlayers(joinedLobby);
    }
    private void PrintPlayers(Lobby lobby)
    {
        foreach (Player player in lobby.Players)
        {
            Debug.Log(player.Id);
        }
    }
    private async void UpdatePlayerName(string newPlayerName)
    {
        try
        {
            playerName = newPlayerName;
            await LobbyService.Instance.UpdatePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId, new UpdatePlayerOptions
            {
                Data = new Dictionary<string, PlayerDataObject> {
                    { "PlayerName", new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, playerName) }
                }
            });
        }

        catch (LobbyServiceException e)
        {

            Debug.Log(e);
        }
    }

    private async void LeaveLobby()
    {
        try
        {
        await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, AuthenticationService.Instance.PlayerId);
        }
        catch (LobbyServiceException e)
        {

            Debug.Log(e);
        }
    }
    private async void KickPlayer()
    {
        try
        {
            await LobbyService.Instance.RemovePlayerAsync(joinedLobby.Id, joinedLobby.Players[1].Id);
        }
        catch (LobbyServiceException e)
        {

            Debug.Log(e);
        }
    }
}
