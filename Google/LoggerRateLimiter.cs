/*
У вас есть логгер, который должен печатать сообщения. Логгер должен печатать каждое сообщение 
не более одного раза за каждые 10 секунд. Если одно и то же сообщение было выведено в течение 
последних 10 секунд, оно должно быть проигнорировано.
*/
using System;
using System.Collections.Generic;
class Logger
{
  Dictionary<string, DateTime> messageLastTime = new Dictionary<string, DateTime>();
  public bool ShouldPrintMessage(DateTime timestamp, string message)
  {
    if (!messageLastTime.ContainsKey(message)) {
      messageLastTime.Add(message, timestamp);
      return true; 
    } else {
      DateTime last = messageLastTime[message];
      TimeSpan dif = timestamp - last;
      if (dif.TotalSeconds() >= 10) {
        messageLastTime[message] = timestamp;
        return true;
      }
      return false;
    }
  }
}
class Program
{
  static void Main(string[] args)
  {

  }
}