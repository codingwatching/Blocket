using UnityEngine;

/// <summary>
/// Used for Global (Unique) Variables/Settings
/// <br></br>
/// <b>Use it gently!</b>
/// </summary>
public static class GlobalVariables {

	public static readonly ushort maxItemCountForMultiple = 128;
	public static string chunkTag = "Chunk";

	public static GameObject networkVariablesGO;
	private static NetworkVariables _networkVariables;
	public static NetworkVariables NetworkVariables { get => _networkVariables; set {
			_networkVariables = value;
			networkVariablesGO = value.gameObject;
		}
	}

	#region UIScripts
	public static UILobby UILobby { get; set; }
	public static UIProfileSite UIProfileSite { get; set; }
	#endregion

	#region Multiplayer
	public static string ipAddress = UILobby.GetLocalIPAddress();
	public static int portAddress = 7777;
	public static bool muliplayer = false;
	#endregion

	#region Properties + Fields
	public static GameManager GameManager { get; set; }
	public static GameObject LocalUI { get => _localUI; set
		{
			_localUI = value;
			UIInventory = value.GetComponentInChildren<UIInventory>();
		}
	}
	private static GameObject _localUI;
	//public static readonly List<GameObject> players = new List<GameObject>();

	#region Assets
	public static GameObject GlobalAssets { get => _globalAssets; set {
			_globalAssets = value;
			_prefabAssets = value.GetComponent<PrefabAssets>();
		}
	}
	private static GameObject _globalAssets;
	public static PrefabAssets PrefabAssets { get => _prefabAssets; }
	private static PrefabAssets _prefabAssets;
	public static ItemAssets ItemAssets { get; set; }
	#endregion

	public static WorldData WorldData { get; set; }
	public static TerrainGeneration TerrainGeneration { get; set; }
	public static TerrainHandler TerrainHandler { get; set;}

	public static GameObject World { get => _world; set { 
			_world = value;
		} 
	}
	private static GameObject _world;

	public static UIInventory UIInventory { get; set; }

	#region LocalPlayer
	public static Inventory Inventory { get => _inventory; }
	private static Inventory _inventory; 
	public static PlayerVariables PlayerVariables { get => _playerVariables; }
	private static PlayerVariables _playerVariables;
	public static Vector3 LocalPlayerPos { get => LocalPlayer.transform.position; }

	public static GameObject LocalPlayer
	{
		get => _localPlayer; set
		{
			_localPlayer = value;
			_playerVariables = value.GetComponent<PlayerVariables>();
			_inventory = value.GetComponentInChildren<Inventory>();
		}
	}
	private static GameObject _localPlayer;
	#endregion
	#endregion
}
