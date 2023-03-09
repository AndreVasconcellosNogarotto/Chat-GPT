using Newtonsoft.Json;
using System.Text;

do
{
    var question = Console.ReadLine();

    if (question?.Length <= 0)
        Console.WriteLine("Escreva uma pergunta valida.");
    else
    {
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("authorization", "Bearer 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");

        var json = JsonConvert.SerializeObject(new
        {
            model = "text-davinci-003",
            prompt = question,
            max_tokens = 500,
            temperature = 0
        });

        var httpResponse = await client.PostAsync("https://api.openai.com/v1/completions", new StringContent(json, Encoding.UTF8, "application/json"));

        var data = await httpResponse.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<dynamic>(data);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(response.choices[0].text);

        Console.WriteLine();
        Console.ResetColor();
    }

}
while (true);