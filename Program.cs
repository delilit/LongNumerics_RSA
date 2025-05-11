using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using Longnumerics;
using Testes;
class Program{
    static void Main(){
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
    
        // Tester test = new Tester();
        // test.testing();
        
        // BigInt p = new BigInt("61");
        // BigInt q = new BigInt("53");
        // BigInt n = p * q; // 3233
        // BigInt phi = (p - new BigInt("1")) * (q - new BigInt("1"));

        // BigInt e = new BigInt("11");
        // BigInt d = BigInt.ModInverse(e, phi);

        // BigInt message = new BigInt("43");

        // BigInt encrypted = BigInt.ModPow(message, e, n);
        // Console.Write("Encrypted: "); encrypted.print();

        // BigInt decrypted = BigInt.ModPow(encrypted, d, n);
        // Console.Write("Decrypted: "); decrypted.print();
    }