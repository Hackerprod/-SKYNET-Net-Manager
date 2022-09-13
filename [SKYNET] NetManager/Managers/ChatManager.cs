using SKYNET.Types;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SKYNET
{
    public class ChatManager
    {
        public static ConcurrentDictionary<IPAddress, frmPrivateChat> Chats;
        public static ConcurrentDictionary<IPAddress, List<ChatMessage>> ChatsHistory;

        public static void Initialize()
        {
            Chats = new ConcurrentDictionary<IPAddress, frmPrivateChat>();
            ChatsHistory = new ConcurrentDictionary<IPAddress, List<ChatMessage>>();

            MessageProcessor processor = new MessageProcessor();
            processor.OnMessageReceived = OnMessageReceived;
            processor.Start();

        }

        private static void OnMessageReceived(object sender, MessageProcessor.MessageReceived e)
        {
            if (Chats.TryGetValue(e.Address, out var Chat))
            {
                Chat.PrintMessage(e);
            }
            else
            {
                var chat = new frmPrivateChat(e.Address);

                RegisterChat(e.Address, chat);

                if (ChatsHistory.TryGetValue(e.Address, out var messages))
                {
                    chat.FillHistory(messages);
                }

                chat.PrintMessage(e);
                chat.ShowDialog();
            }
        }

        public static void RegisterMessage(IPAddress address, ChatMessage message)
        {
            if (ChatsHistory.TryGetValue(address, out var chatHistory))
            {
                chatHistory.Add(message);
            }
            else
            {
                chatHistory = new List<ChatMessage>() { message };
                ChatsHistory.TryAdd(address, chatHistory);
            }
        }

        public static void RegisterMessage(IPAddress address)
        {
            if (!ChatsHistory.TryGetValue(address, out var chatHistory))
            {
                chatHistory = new List<ChatMessage>();
                ChatsHistory.TryAdd(address, chatHistory);
            }
        }

        public static bool GetChat(IPAddress address, out frmPrivateChat chat)
        {
            return Chats.TryGetValue(address, out chat);
        }

        public static void RegisterChat(IPAddress address, frmPrivateChat form)
        {
            //if (address == null || form == null)
            //{
            //    return;
            //}

            if (!Chats.ContainsKey(address))
            {
                Chats.TryAdd(address, form);
            }
            if (!ChatsHistory.ContainsKey(address))
            {
                ChatsHistory.TryAdd(address, new List<ChatMessage>());
            }
        }

        public static void RemoveChat(IPAddress iPAddress)
        {
            Chats.TryRemove(iPAddress, out _);
        }

        public static bool GetChatHistory(IPAddress Address, out List<ChatMessage> chatHistory)
        {
            return ChatsHistory.TryGetValue(Address, out chatHistory);
        }
    }
}
