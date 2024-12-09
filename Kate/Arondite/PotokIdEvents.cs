using System;
using System.Collections.Generic;

class Event
{
  public string EventId { get; set; } // Уникальный ID события
  public DateTime Timestamp { get; set; } // Временная метка события
}

public class EventManager
{
  private Queue<Event> events; // Очередь событий
  private Dictionary<string, int> dictFrequency; // Словарь частот событий
  private Dictionary<string, Event> dictEvents; // Словарь для хранения последнего объекта события
  private string mostFrequentId = null; // ID самого частого события

  public EventManager()
  {
    events = new Queue<Event>();
    dictFrequency = new Dictionary<string, int>();
    dictEvents = new Dictionary<string, Event>();
  }

  // Обработка нового события
  public void ProcessEvent(Event newEvent)
  {
    events.Enqueue(newEvent);

    string id = newEvent.EventId;

    // Обновляем частоты и храним последнее событие
    if (dictFrequency.ContainsKey(id))
    {
      dictFrequency[id]++;
    }
    else
    {
      dictFrequency[id] = 1;
      dictEvents[id] = newEvent;
    }

    // Обновляем mostFrequentId
    if (mostFrequentId == null || dictFrequency[id] > dictFrequency[mostFrequentId])
    {
      mostFrequentId = id;
    }

    // Удаляем старые события
    DeleteOldEvents(newEvent.Timestamp);
  }

  // Удаление старых событий
  private void DeleteOldEvents(DateTime currentTime)
  {
    while (events.Count > 0)
    {
      Event first = events.Peek();
      TimeSpan timeDiff = currentTime - first.Timestamp;

      // Если событие старше 10 минут, удаляем его
      if (timeDiff.TotalSeconds >= 600)
      {
        events.Dequeue();

        string id = first.EventId;

        // Уменьшаем частоту в dictFrequency
        dictFrequency[id]--;
        if (dictFrequency[id] == 0)
        {
          dictFrequency.Remove(id);
          dictEvents.Remove(id);
        }

        // Если самое частое событие удалено, пересчитываем mostFrequentId
        if (mostFrequentId == id)
        {
          RecalculateMostFrequent();
        }
      }
      else
      {
        break; // Остальные события находятся в пределах 10 минут
      }
    }
  }

  // Пересчёт самого частого события
  private void RecalculateMostFrequent()
  {
    mostFrequentId = null;
    int maxFrequency = 0;

    foreach (var pair in dictFrequency)
    {
      if (pair.Value > maxFrequency)
      {
        mostFrequentId = pair.Key;
        maxFrequency = pair.Value;
      }
    }
  }

  // Получение самого частого события
  public Event GetMostFrequentEvent()
  {
    if (mostFrequentId != null && dictEvents.ContainsKey(mostFrequentId))
    {
      return dictEvents[mostFrequentId];
    }
    throw new InvalidOperationException("No events available.");
  }
}
