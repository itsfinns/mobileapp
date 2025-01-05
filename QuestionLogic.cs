namespace mobileapp
{
    public class QuestionLogic
    {
        public async static Task<List<Question>> GetQuestionAtRandom(string questions)
        {
            List<Question> question = new List<Question>();

            var url = Question.GenerateURLName(questions);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }
        }
    }
}