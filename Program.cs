using Longnumerics;
class Program{
    static void Main(){
        BigInt big = new BigInt("12344123");
        BigInt big2 = new BigInt("-12344123");
        big.print();
        Console.WriteLine(big == big2);
    }
}