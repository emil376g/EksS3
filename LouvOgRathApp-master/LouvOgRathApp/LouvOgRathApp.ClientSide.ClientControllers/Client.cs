using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using LouvOgRathApp.Shared.TcpCommunications;
using System.Text;
using System.Threading.Tasks;
using LouvOgRathApp.Shared.Entities;

namespace LouvOgRathApp.ClientSide.ClientControllers
{
    public class Client : ServerCommunicationsHandler
    {
        public Client(IPEndPoint remoteEndPoint) : base(remoteEndPoint)
        {
        }

        public bool Connect()
        {
            Client client = new Client(remoteEndPoint);
            return base.client.Connected;
        }
        public bool ClientConnected()
        {
            return client.Connected;
        }
        public IPersistable[] GetAllCases()
        {
            return GetDataFromServer(RequestedAction.GetAllCases);
        }
        public IPersistable[] GetDataFromServer(RequestedAction action)
        {
            byte[] buffer = Serializer<ClientRequest>.Serialize(new ClientRequest(action));
            byte[] bufferReceiver = Transmit(buffer);
            return Serializer<TransmissionData>.Deserialize(bufferReceiver).Entities;
        }
        public IPersistable[] SaveCase(Case[] @case)
        {
            IPersistable[] persistable = @case;
            return SentRequestToServer(RequestedAction.SaveNewCase, persistable.ToList());
        }
        public IPersistable[] GetAllSummerys()
        {
            return GetDataFromServer(RequestedAction.GetAllSummerysById);
        }
        public IPersistable[] SaveSummery(MettingSummery[] summery)
        {
            IPersistable[] persistable = summery;
            return SentRequestToServer(RequestedAction.SaveNewSummery, persistable.ToList());
        }
        public IPersistable SentRequestToServer(RequestedAction action, IPersistable data)
        {
            TransmissionData transmitData = new TransmissionData(data);
            byte[] buffer = Serializer<ClientRequest>.Serialize(new ClientRequest(action, transmitData));
            byte[] bufferReceiver = Transmit(buffer);
            return Serializer<TransmissionData>.Deserialize(bufferReceiver).Entity;
        }
        public IPersistable[] SentRequestToServer(RequestedAction action, List<IPersistable> data)
        {
            if (!client.Connected)
            {
                client.Connect(remoteEndPoint);
            }
            TransmissionData transmitData = new TransmissionData(data);
            byte[] buffer = Serializer<ClientRequest>.Serialize(new ClientRequest(action, transmitData));
            byte[] bufferReceiver = Transmit(buffer);
            client.Dispose();
            return Serializer<TransmissionData>.Deserialize(bufferReceiver).Entities;
        }
        public TransmissionData ResponseDataFromServer()
        {
            byte[] buffer = new byte[bufferSize];
            Transmit(buffer);
            return Serializer<TransmissionData>.Deserialize(buffer);
        }
    }
}
