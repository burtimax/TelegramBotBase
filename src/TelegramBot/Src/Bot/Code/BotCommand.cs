using System.Threading.Tasks;

namespace BotApplication.Bot.Code
{
    public class BotCommand
    {
        public delegate Task<Hop> ExecutionMethod(UpdateBotModel data);
        private ExecutionMethod executionMethod;


        /// <summary>
        /// Text command instruction
        /// </summary>
        public string Instruction { get; set; }

        public BotCommand(string strInstruction, ExecutionMethod method = null)
        {
            this.executionMethod = method;
            this.Instruction = strInstruction;
        }

        /// <summary>
        /// Process command method
        /// </summary>
        /// <param name="data">Data for Processing</param>
        public virtual Task<Hop> ExecCommand(UpdateBotModel data)
        {
            return executionMethod?.Invoke(data);
        }

    }
}
