using Nova.Discord;

class Program {
    public static void Main(string[] args) {
        Bot bot = new Bot("Nzk1NzU1ODUxOTgxMzg5ODY0.GBA9fZ.sHHGbtbOMN6kyu4vcKXCOYq8FQ9-KvPkJuu41M");
        bot.Run().GetAwaiter().GetResult();
    }
}