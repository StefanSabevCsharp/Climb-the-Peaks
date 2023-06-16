int[] foodInts = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] staminaInts = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Stack<int> food = new Stack<int>(foodInts);
Queue<int> stamina = new Queue<int>(staminaInts);
Queue<string> strings = new Queue<string>();
strings.Enqueue("Vihren");
strings.Enqueue("Kutelo");
strings.Enqueue("Banski Suhodol");
strings.Enqueue("Polezhan");
strings.Enqueue("Kamenitza");
Queue<string> result = new Queue<string>();
for (int i = 0; i < 7; i++)
{
    if (food.Count == 0 || stamina.Count == 0)
    {
        break;
    }
   int currentFood = food.Pop();
    int currentStamina = stamina.Dequeue();
    int sum = currentFood + currentStamina;
    if (sum >= 80 && strings.Contains("Vihren"))
    {
        
        string currentString = strings.Dequeue();
        result.Enqueue(currentString);
      
    }
    else if (sum >= 90 && strings.Contains("Kutelo") && result.Contains("Vihren"))
    {
      
        string currentString = strings.Dequeue();
        result.Enqueue(currentString);
    }
    else if (sum >= 100 && strings.Contains("Banski Suhodol") &&  result.Contains("Vihren"))
    {
       
        string currentString = strings.Dequeue();
        result.Enqueue(currentString);
    }
    else if (sum >= 60 && strings.Contains("Polezhan") && result.Contains("Banski Suhodol"))
    {
        string currentString = strings.Dequeue();
        result.Enqueue(currentString);
    }
    else if(sum >= 70 && strings.Contains("Kamenitza") && result.Contains("Polezhan"))
    {
        string currentString = strings.Dequeue();
        result.Enqueue(currentString);
    }
}
if (result.Count == 5)
{
    Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
    Console.WriteLine("Conquered peaks:");
   
        Console.WriteLine(string.Join(Environment.NewLine, result));

    
}
else
{
    Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
    Console.WriteLine(string.Join(Environment.NewLine,result));
}