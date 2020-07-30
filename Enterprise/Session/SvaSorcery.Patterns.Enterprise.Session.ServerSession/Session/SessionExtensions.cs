using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace SvaSorcery.Patterns.Enterprise.Session.ServerSession.Session
{
    public static class SessionExtensions
    {
        private const string key = "Recognitions";

        public static void Remove(this ISession session)
        {
            session.Remove(key);
        }

        public static void Set(this ISession session, QueryObject value)
        {
            if (value == null)
                return;

            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream, Encoding.UTF8, true);
            writer.Write(value.ContractId);
            writer.Write(value.RecognizedAt?.ToString(@"yyyy/MM/dd"));

            session.Set(key, stream.ToArray());
        }

        public static bool TryGetValue(this ISession session, out QueryObject value)
        {
            if (session.TryGetValue(key, out byte[] buffer))
            {
                using var stream = new MemoryStream(buffer);
                using var reader = new BinaryReader(stream, Encoding.UTF8, true);
                var contractId = reader.ReadInt32();
                var recognizedAt = DateTime.Parse(reader.ReadString());

                value = new QueryObject(contractId, recognizedAt);
                return true;
            }

            value = null;
            return false;
        }
    }
}
