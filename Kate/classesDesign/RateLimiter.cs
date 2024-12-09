using System;
public class RateLimiter{
    public Dictionary<string, (DateTime lastRequestTime, int requestCount)> users; //id, when last request was done and number of requests
    public int limit;
    public int timeSlot;
    public RateLimiter(int limit, int timeSlot) {
        this.users = new Dictionary<string, (DateTime, int)>();
        this.limit = limit;
        this.timeSlot = timeSlot;
    }

    public bool AllowRequest(string id) {
        DateTime currentTime = DateTime.UtcNow;
        if (users.ContainsKey(id)) {
            DateTime lastTime = users[id].lastRequestTime;
            int requestsDone = users[id].requestCount;
            // Вычисляем разницу
            TimeSpan timeDifference = currentTime - lastTime;
            // Получаем количество секунд, прошедших между двумя временами
            double secondsPassed = timeDifference.TotalSeconds;
            if (secondsPassed > timeSlot) {
                users[id] = (currentTime, 1);
                return true;
            } else {
                if (requestsDone < limit) {
                    users[id] = (lastTime, requestsDone+1);
                    return true;
                } else {
                    Console.WriteLine("You have to wait");
                    return false;
                }
            }
        } else {
            users.Add(id, (currentTime, 1));
            return true;
        }
    }
}