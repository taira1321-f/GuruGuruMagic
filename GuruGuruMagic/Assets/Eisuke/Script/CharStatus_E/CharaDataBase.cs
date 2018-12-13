using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Player/CreateDB")]
public class CharaDataBase : ScriptableObject {
    public List<CharaData> CharaDataList = new List<CharaData>();
}
