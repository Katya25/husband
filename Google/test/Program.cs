using System;
using System.Runtime.Intrinsics.Arm;
using System.Security.AccessControl;

class Program {

  static int solution2(int[] loads) {
    // put your solution here
    //System.err.println("Tip: Use System.err.println() to write debug messages on the output tab.");
    int sum = 0;
    foreach (int i in loads) {
        sum += i;
    }

    int target = sum / 2;

    HashSet<int> sums = new HashSet<int> {0};

    foreach (int i in loads) {
        List<int> curSums = new List<int> (sums);
        foreach (int s in curSums) {
            int newS = s + i;
            if (newS == target) {
                if (sum % 2 == 0) return 0;
                else return 1;
            }
            sums.Add(newS);
        }
    }

    for (int i = target - 1; i > 0; i--) {
        if (sums.Contains(i)) {
            int rest = sum - i;
            return rest - i;
        }
    }
    
    return 0;
  }

  static int Solution1(int[] A) {
    // Your solution goes here.
    Dictionary<int, int> dict = new Dictionary<int, int>(); //lowest, count of rows
    
    foreach (int i in A) {
        int smallestTop = int.MaxValue;
        foreach (int key in dict.Keys) {
            if (key > i && key < smallestTop) {
                smallestTop = key;
            }
        }

        if (smallestTop != int.MaxValue) {
            dict[smallestTop]--;
            if (dict[smallestTop] == 0) {
                dict.Remove(smallestTop);
            }
        }
        if (dict.ContainsKey(i)){
            dict[i]++;
        } else {
            dict.Add(i, 1);
        }
        
    }
    
    int sum = 0;
    foreach (int val in dict.Values) {
      sum += val;
    }
      
    return sum;
  }
public static int solution(int[] points, string tokens){
  //points = [3, 4, 5, 2, 3] and 
  //tokens = "T  E  E  T  T"
  if (points.Length != tokens.Length) {
    return 0;
  }
  
  int sum = 0;
  if (tokens[0] == 'T') {
    sum += points[0];
  }
  for (int i = 1; i < points.Length; i++) {
    if (tokens[i] == 'T') {
        sum += points[i];
        if (tokens[i-1] == 'T') {
            sum++;
        }
    }
  }
  return sum;
}
  public static int solution2(int S){
    
    int count = 0;
    for (int i = 0; i <= 9; i++) {
        for (int j = 0; j <= 9; j++) {
            for (int v = 0; v <=9; v++) {
                for (int z = 0; z <= 9; z++) {
                    int sum = i + j + v + z;
                    if (sum == S) {
                        count++;
                    }
                }
            }
        }
    }
    return count;
  }

  static void Main(String[] args) {
    // Read from stdin, solve the problem, write answer to stdout.
    int[] A = {3,2,1,5,4,6,3,1,2};

    int S = 5;

    int[] points = { 3,2,1,2,2 };
    string tokens = "ETTTE";
    Console.Write(solution(points, tokens));
    //3 2 1 
    //5 4 3 1
    //6 2

    //Console.Write(Solution(A));
  }
}