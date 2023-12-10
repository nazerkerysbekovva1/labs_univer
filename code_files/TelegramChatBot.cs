using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
//using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using System.IO;
using File = System.IO.File;
using Telegram.Bot.Types.Enums;
using Microsoft.VisualBasic;

namespace TelegramBotExperiments
{
    internal class ChatBot
    {
        public string bot;
        public ChatBot(string token)
        {
            bot = token;
        }
    }

    class Program
    {
        static string Trim(string str, char[] chars)
        {
            string strA = str;
            for (int i = 0; i < chars.Length; i++)
            {
                strA = strA.Replace(char.ToString(chars[i]), "");
            }
            return strA;
        }

        static string[] baza = File.ReadAllLines("C:\\Users\\nazer\\OneDrive\\Desktop\\chat.txt");

        static ChatBot chatbot = new ChatBot("5892193964:AAGs8eFp6-YR7WEQfBlYg9sUO0SaDDPokj8");

        static ITelegramBotClient bot = new TelegramBotClient(chatbot.bot);

        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Обрабатывать только обновления сообщений
            if (update.Message is not { } message)
                return;
            // Обрабатывать только текстовые сообщения
            if (message.Text is not { } messageText)
                return;

            // Only process photo messages
            //if (message.Photo is not { } photo)
            //    return;

            string tr = ")(:^^=!?";
            messageText = Trim(messageText, tr.ToCharArray());

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            if (messageText == "/start")
            {
                Message sentMessage = await botClient.SendTextMessageAsync(      //Этот метод отправляет текстовое сообщение и возвращает отправленный объект сообщения.
                   chatId: chatId,
                   text: "привет мой друг! я Chatbot! \nДавай пообщаться?!",
                   cancellationToken: cancellationToken);
                return;
            }
            for (int i = 0; i < baza.Length; i++)
            {
                if (messageText == baza[i])
                {
                    baza[i + 1] = Trim(baza[i + 1], tr.ToCharArray());
                    // Эхо полученного текста сообщения
                    Message sentMessage = await botClient.SendTextMessageAsync(
                        chatId: chatId,
                        text: baza[i + 1],
                        cancellationToken: cancellationToken);
                    return;
                }
            }
            await botClient.SendTextMessageAsync(message.Chat, "извини не понял");

            if (messageText == "фото")
            {
                Message mes = await botClient.SendPhotoAsync(  //Этот метод отправляет фотосообщение
                    chatId: chatId,
                    photo: "https://i2.wp.com/factcheck.kz/wp-content/uploads/2020/05/123-1.jpg?fit=1200%2C800&ssl=1",
                    caption: "<b>Univer KazNu</b>",
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);
                return;
            }
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        static async Task Main(string[] args)
        {
            using var cts = new CancellationTokenSource();

            // StartReceiver не блокирует вызывающий поток. Получение выполняется в ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // получаем все типы обновлений
            };
            bot.StartReceiving(
                updateHandler: HandleUpdateAsync,
                pollingErrorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = await bot.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Отправляем запрос на отмену, чтобы остановить бота
            cts.Cancel();

            Console.ReadLine();
        }
    }
}