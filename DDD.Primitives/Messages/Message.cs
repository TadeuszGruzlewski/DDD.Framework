using DDD.Foundations;

namespace DDD.Primitives.Messages;

public abstract record class Message(int Code, string Name, string Text) : Enumeration(Code, Name);
