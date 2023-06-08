namespace API.Application.Core
{   
    public class RandomResponse
    {
        private const string PONG = "PONG";
        private const string PING = "PING";
        private static readonly string[] QUESTION = {"What is your quest?","What is your quest?"};
        private const string ANSWER = "coding";
        private const string FREE = "free response";  

        public RandomResponse()
        {
            
        }
        public static bool ValidateRandomQuestions(string q){
                return !((q.Contains(PING) || QUESTION.Contains(q.Trim())));
        }
        public static string GenerateRandomResponse(string q){
                if(q.Contains(PING)){
                        return PONG;
                }
                if(QUESTION.Contains(q)){
                        return ANSWER;
                }
                return FREE;
         }
    }
}