//   Project : Actors
//  Contacts : Pixeye - ask@pixeye.games 

using UnityEngine;

namespace Pixeye.Framework
{
    [CreateAssetMenu(fileName = "GameSession", menuName = "Actors Framework/Add/Data/GameSession")]
	public class GameSession : DataSession, IKernel
    {
        public static GameSession Default => Toolbox.Get<GameSession>();

        public float MoveTime = 0.1f; // Время движения объекта в секундах
        public LayerMask blockingLayer; // Слой, на котором проверяются коллизии
        
    }
}
