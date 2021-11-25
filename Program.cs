internal class Program {
	private static async Task Multiply(string firstNumber, string secondNumber, int i) {
		var content = $"{firstNumber},{secondNumber}";
		var client = new HttpClient();
		var response = await client.PostAsync($"http://localhost:808{i + 1}/task", new StringContent(content));
		var responseContent = await response.Content.ReadAsStringAsync();
		Console.WriteLine($"{responseContent}");
	}

	private static bool CheckArgs(string[] args) => args.Length >= 1 && args.Length % 2 == 0;
	private static async Task Main(string[] args) {
		if (!CheckArgs(args)) {
			return;
		}
		for (var i = 0; i < args.Length; i += 2) {
			await Multiply(args[i], args[i + 1], i);
		}
	}
}