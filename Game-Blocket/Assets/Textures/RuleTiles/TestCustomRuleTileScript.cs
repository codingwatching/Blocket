using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TestCustomRuleTileScript : RuleTile<TestCustomRuleTileScript.Neighbor> {

    public static Sprite spriteDefault;
    public static Sprite sprite1;
    public static Sprite sprite2;
    public static Sprite sprite3;
    public bool customField;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public Vector2Int position;
        public const int Null = 3;
        public const int NotNull = 4;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.Null: 
                if(GlobalVariables.WorldData.ChunkHeight)
                return tile == null;
            case Neighbor.NotNull: return tile != null;
        }
        return base.RuleMatch(neighbor, tile);
    }
    
 static void CreateRuleTile()
 {
     RuleTile ruleTile = ScriptableObject.CreateInstance("RuleTile") as RuleTile;
 
     AssetDatabase.CreateAsset(ruleTile, "Assets/" + UnityEngine.Random.Range(0, 999).ToString() + "MyRuleTile.asset");
 
     Debug.Log(AssetDatabase.GetAssetPath(ruleTile));
     ruleTile.m_DefaultSprite = spriteDefault;
 
     RuleTile.TilingRule rule01 = new RuleTile.TilingRule();
     rule01.m_Sprites[0] = sprite1;
 
     RuleTile.TilingRule rule02 = new RuleTile.TilingRule();
     rule02.m_Sprites[0] = sprite2;
 
     RuleTile.TilingRule rule03 = new RuleTile.TilingRule();
     rule03.m_Sprites[0] = sprite3;
 
 
     ruleTile.m_TilingRules.Add(rule01);
     ruleTile.m_TilingRules.Add(rule02);
     ruleTile.m_TilingRules.Add(rule03);
 
 }
 
    Dictionary<Vector3Int, int> dict = rule01.GetNeighbors();
    List<Vector3Int> neighbors = rule01.m_NeighborPositions;
    for(int i = 0; i<neighbors.Count; i++)
    {
        dict.Add(neighbors[i], RuleTile.TilingRuleOutput.Neighbor.This);
    }
    rule01.ApplyNeighbors(dict);

}