using System.Collections.Generic;
using BotApplication.Bot.Db.DbBot;

namespace BotApplication.Bot.Code
{
    public abstract class BotStateStorage
    {
        public Dictionary<string, BotState> States = null;

        protected BotStateStorage()
        {
            InitStates();
        }

        protected abstract void InitStates();

        /// <summary>
        /// Get BotState object By State BotNamespaceStatePrefix.
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public BotState GetStateByChatData(Chat chat)
        {
            if (States == null || States.Count == 0) return null;

            var tmpChatName = chat.GetCurrentStateName();
            if (States.ContainsKey(tmpChatName))
            {
                return States[tmpChatName];
            }

            return null;
        }

        /// <summary>
        /// Get BotState object By State BotNamespaceStatePrefix and put Data
        /// </summary>
        /// <param name="stateName"></param>
        /// <returns></returns>
        public BotState Get(string stateName)
        {
            if (States == null || States.Count == 0) return null;

            if (States.ContainsKey(stateName))
            {
                return States[stateName];
            }

            return null;
        }
    }
}
