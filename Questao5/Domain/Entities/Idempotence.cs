namespace Questao5.Domain.Entities
{
    public class Idempotence
    {
        public Idempotence(string id, string request, string result)
        {
            Id = id;
            Request = request;
            Result = result;
        }

        public string Id { get; set; }
        public string? Request { get; set; }
        public string? Result { get; set; }

    }
}
