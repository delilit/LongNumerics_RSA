using System;
using System.Text;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Longnumerics;
using Testes;
class Program{
    static void drain(){
        // Запустить тесты
        Tester test = new Tester();
        test.testing();
        
        StreamReader sr = new StreamReader("D:\\Learn\\Алгосы\\LR2\\message.txt");
        string line = sr.ReadLine();
        BigInt message = new BigInt(line);

        
        int number = 3;
        int[] numbers = new int[] {0, 0};

        while (true){
        
            if (is_prime(number)){
                numbers[0] = numbers[1];
                numbers[1] = number;
            }    
            number += 1;
            BigInt result = new BigInt((numbers[0] * numbers[1]).ToString());
            if (result > message) {break;}
            }


        BigInt p = new BigInt(numbers[0].ToString());
        BigInt q = new BigInt(numbers[1].ToString());
        BigInt n = p * q;
        BigInt phi = (p - new BigInt("1")) * (q - new BigInt("1"));
        BigInt e = new BigInt("3");


        BigInt y = new BigInt("0");
        BigInt x = new BigInt("0");
        while (BigInt.ExtendedGCD(e, phi, out x, out y) != new BigInt("1"))
        {
            e += new BigInt("2");
        }
        BigInt d = BigInt.ModInverse(e, phi);

        
        BigInt encrypted = BigInt.ModPow(message, e, n);
        Console.Write("Encrypted: "); encrypted.print();

        BigInt decrypted = BigInt.ModPow(encrypted, d, n);
        Console.Write("Decrypted: "); decrypted.print();
        }
        
    public static bool is_prime(int number){
        for (int i = 2; i<Math.Pow(number, 0.5); i++){
            if (number % i == 0){
            return false;
            }
        }
        return true;
    }
    static void Main(){
        Encoding ascii = Encoding.ASCII;
        String unicodeString =
          "This unicode string contains two characters " +
          "with codes outside the ASCII code range, " +
          "Pi (\u03a0) and Sigma (\u03a3).";
      Console.WriteLine("Original string:");
      Console.WriteLine(unicodeString);

      // Save the positions of the special characters for later reference.
      int indexOfPi = unicodeString.IndexOf('\u03a0');
      int indexOfSigma = unicodeString.IndexOf('\u03a3');

      // Encode the string.
      Byte[] encodedBytes = ascii.GetBytes(unicodeString);
      Console.WriteLine();
      Console.WriteLine("Encoded bytes:");
      foreach (Byte b in encodedBytes) 
      {
          Console.Write($"[{b}]");
      }
      Console.WriteLine();

      String decodedString = ascii.GetString(encodedBytes);
      Console.WriteLine();
      Console.WriteLine("Decoded bytes:");
      Console.WriteLine(decodedString);
    }
    }