using System.Collections.Generic;

public interface IMessageHandler
{
    void CallResponse();
    void SetPayload(Dictionary<string, string> payload);
}