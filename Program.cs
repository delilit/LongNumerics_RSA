using Longnumerics;
using Testes;
class Program{
    static void Main(){
        Tester test = new Tester();
        test.testing();
        
        BigInt p = new BigInt("61");
        BigInt q = new BigInt("53");
        BigInt n = p * q; // 3233
        BigInt phi = (p - new BigInt("1")) * (q - new BigInt("1"));

        BigInt e = new BigInt("11");
        BigInt d = BigInt.ModInverse(e, phi);

        BigInt message = new BigInt("43");

        BigInt encrypted = BigInt.ModPow(message, e, n);
        Console.Write("Encrypted: "); encrypted.print();

        BigInt decrypted = BigInt.ModPow(encrypted, d, n);
        Console.Write("Decrypted: "); decrypted.print();
    }
}