using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Channels;

namespace Longnumerics{
public class BigInt
{
    private int[] digits;
    private bool isNegative;

    private BigInt(int[] digits, bool isNegative)
    {
        this.digits = digits;
        this.isNegative = isNegative;
    }
    public BigInt(string str){
        if (str.StartsWith("-"))
        {
            str = str.Substring(1); 
            isNegative = true;
        }

        int[] result = new int[str.Length];
        for (int i =0 ; i<str.Length; i++){
            if (!char.IsDigit(str[i]))
                throw new FormatException("Input string contains non-numeric characters.");
            result[i] = str[i]-'0';
        }
        digits = result;
    }
    public void print(){
        if (this.isNegative){
            Console.Write("-");
        }
        foreach (var value in this.digits){
            Console.Write($"{value}");
        }
        Console.Write("\n");
    }
    public static bool operator == (BigInt a, BigInt b){
        if (a.digits.Length == 1 && a.digits[0] == 0 && b.digits.Length == 1 && b.digits[0] == 0) return true;
        if (a.isNegative != b.isNegative)
            return false;
        if (a.digits.Length != b.digits.Length){
            return false;
        }
        for (int i = 0; i<a.digits.Length; i++){
            if (a.digits[i]!=b.digits[i]){
                return false;
            }
        }
        return true;
    }

    public static bool operator != (BigInt a, BigInt b){
        if (a.digits.Length == 1 && a.digits[0] == 0 && b.digits.Length == 1 && b.digits[0] == 0) return false;
        if (a.isNegative != b.isNegative)
            return true;
        if (a.digits.Length != b.digits.Length){
            return true;
        }
        for (int i = 0; i<a.digits.Length; i++){
            if (a.digits[i]!=b.digits[i]){
                return true;
            }
        }
        return false;
    }

    public static bool operator > (BigInt a, BigInt b){
        if (a.digits.Length == 1 && a.digits[0] == 0 && b.digits.Length == 1 && b.digits[0] == 0) return false;
            bool notequal = a.isNegative != b.isNegative;
            if (notequal){
            if (a.isNegative == false & b.isNegative == true){
                return true;
            }
            else return false;
            }
            if (a.isNegative == false){
                if (a.digits.Length > b.digits.Length) return true;
                if (a.digits.Length < b.digits.Length) return false;
                for (int i = 0; i< a.digits.Length; i++){
                    if (a.digits[i] > b.digits[i]) return true;
                    if (a.digits[i] < b.digits[i]) return false;
                }
            }
            else{
                if (a.digits.Length > b.digits.Length) return false;
                if (a.digits.Length < b.digits.Length) return true;
                for (int i = 0; i< a.digits.Length; i++){
                    if (a.digits[i] > b.digits[i]) return false;
                    if (a.digits[i] < b.digits[i]) return true;
                }
        }
        return false;
    }

    public static bool operator < (BigInt a, BigInt b){
            if (a.digits.Length == 1 && a.digits[0] == 0 && b.digits.Length == 1 && b.digits[0] == 0) return false;
            bool notequal = a.isNegative != b.isNegative;
            if (notequal){
            if (a.isNegative == false & b.isNegative == true){
                return false;
            }
            else return true;
            }
            if (a.isNegative == false){
                if (a.digits.Length > b.digits.Length) return false;
                if (a.digits.Length < b.digits.Length) return true;
                for (int i = 0; i< a.digits.Length; i++){
                    if (a.digits[i] > b.digits[i]) return false;
                    if (a.digits[i] < b.digits[i]) return true;
                }
            }
            else{
                if (a.digits.Length > b.digits.Length) return true;
                if (a.digits.Length < b.digits.Length) return false;
                for (int i = 0; i< a.digits.Length; i++){
                    if (a.digits[i] > b.digits[i]) return true;
                    if (a.digits[i] < b.digits[i]) return false;
                }
        }
        return false;
    }
    public static BigInt operator + (BigInt a, BigInt b)
{
    if (a.isNegative == b.isNegative)
    {
        // Сложение по модулю
        List<int> result = AddDigits(a.digits, b.digits);
        return new BigInt(result.ToArray(), a.isNegative);
    }
    else
    {
        // Разные знаки — вычитание по модулю
        int cmp = CompareAbs(a.digits, b.digits);
        if (cmp == 0)
        {
            return new BigInt(new int[] { 0 }, false); // 123 + (-123) = 0
        }
        else if (cmp > 0)
        {
            List<int> result = SubtractDigits(a.digits, b.digits);
            return new BigInt(result.ToArray(), a.isNegative);
        }
        else
        {
            List<int> result = SubtractDigits(b.digits, a.digits);
            return new BigInt(result.ToArray(), b.isNegative);
        }
    }
}
public static BigInt operator - (BigInt a, BigInt b)
{
    if (a.isNegative != b.isNegative)
    {
        // Превращаем в сложение: a - (-b) = a + b
        List<int> result = AddDigits(a.digits, b.digits);
        return new BigInt(result.ToArray(), a.isNegative);
    }
    else
    {
        // Оба одного знака — вычитание по модулю
        int cmp = CompareAbs(a.digits, b.digits);
        if (cmp == 0)
        {
            return new BigInt(new int[] { 0 }, false);
        }
        else if (cmp > 0)
        {
            List<int> result = SubtractDigits(a.digits, b.digits);
            return new BigInt(result.ToArray(), a.isNegative);
        }
        else
        {
            List<int> result = SubtractDigits(b.digits, a.digits);
            return new BigInt(result.ToArray(), !a.isNegative); // знак противоположен a
        }
    }
}
public static BigInt operator * (BigInt a, BigInt b)
{
    int[] result = new int[a.digits.Length + b.digits.Length];

    for (int i = a.digits.Length - 1; i >= 0; i--)
    {
        for (int j = b.digits.Length - 1; j >= 0; j--)
        {
            int mul = a.digits[i] * b.digits[j];
            int p1 = i + j;
            int p2 = i + j + 1;

            int sum = mul + result[p2];
            result[p2] = sum % 10;
            result[p1] += sum / 10;
        }
    }

    int startIndex = 0;
    while (startIndex < result.Length - 1 && result[startIndex] == 0)
        startIndex++;

    int[] trimmedResult = new int[result.Length - startIndex];
    Array.Copy(result, startIndex, trimmedResult, 0, trimmedResult.Length);

    bool resultIsNegative = a.isNegative != b.isNegative;
    return new BigInt(trimmedResult, resultIsNegative);
}
public static BigInt operator / (BigInt dividend, BigInt divisor)
{
    if (divisor.digits.Length == 1 && divisor.digits[0] == 0)
        throw new DivideByZeroException("Cannot divide by zero.");

    bool resultNegative = dividend.isNegative != divisor.isNegative;

    int[] quotient = new int[dividend.digits.Length];
    List<int> remainder = new List<int>();

    for (int i = 0; i < dividend.digits.Length; i++)
    {
        remainder.Add(dividend.digits[i]);
        remainder = TrimLeadingZeros(remainder);

        int x = 0;
        while (CompareAbs(remainder.ToArray(), divisor.digits) >= 0)
        {
            remainder = SubtractDigits(remainder.ToArray(), divisor.digits);
            x++;
        }

        quotient[i] = x;
    }

    quotient = TrimLeadingZeros(quotient.ToList()).ToArray();

    if (quotient.Length == 0)
        return new BigInt(new int[] { 0 }, false);

    return new BigInt(quotient, resultNegative);
}

public static BigInt operator % (BigInt a, BigInt b)
{
    if (b == new BigInt("0"))
        throw new DivideByZeroException();

    BigInt quotient = a / b;
    BigInt product = quotient * b;
    BigInt remainder = a - product;

    if (remainder.isNegative)
        remainder = remainder + b;

    return remainder;
}


private static List<int> TrimLeadingZeros(List<int> digits)
{
    while (digits.Count > 1 && digits[0] == 0)
        digits.RemoveAt(0);
    return digits;
}



private static List<int> AddDigits(int[] a, int[] b)
{
    List<int> result = new List<int>();
    int carry = 0;
    int i = a.Length - 1;
    int j = b.Length - 1;

    while (i >= 0 || j >= 0 || carry > 0)
    {
        int sum = carry;
        if (i >= 0)
        {
        sum += a[i];
        i--;
        }
        if (j >= 0){
            sum += b[j];
            j--;
        }
        result.Insert(0, sum % 10);
        carry = sum / 10;
    }
    return result;
}

private static List<int> SubtractDigits(int[] a, int[] b)
{
    List<int> result = new List<int>();
    int borrow = 0;
    int i = a.Length - 1;
    int j = b.Length - 1;

    while (i >= 0)
    {
        int diff = a[i] - borrow - (j >= 0 ? b[j] : 0);
        if (diff < 0)
        {
            diff += 10;
            borrow = 1;
        }
        else
        {
            borrow = 0;
        }
        result.Insert(0, diff);
        i--; j--;
    }

    while (result.Count > 1 && result[0] == 0)
    {
        result.RemoveAt(0);
    }

    return result;
}

private static int CompareAbs(int[] a, int[] b)
{
    if (a.Length != b.Length)
        return a.Length.CompareTo(b.Length);
    for (int i = 0; i < a.Length; i++)
    {
        if (a[i] != b[i])
            return a[i].CompareTo(b[i]);
    }
    return 0;
}
public static BigInt ModPow(BigInt baseValue, BigInt exponent, BigInt modulus) //Алгоритм быстрого возведения в степень является необходимостью.
{
    BigInt result = new BigInt("1");
    baseValue = baseValue % modulus; // по свойствам остатков мы имеем право работать чисто с ними, ибо умножение чисел и остатков в нашем случае есть одно и то же.

    while (exponent != new BigInt("0"))
    {
        if ((exponent.digits[^1] % 2) == 1)
            result = (result * baseValue) % modulus;
            if (exponent == new BigInt("1")) return result; //ещё одна оптимизация, созданная для того, чтобы не делать лишние операции умножения.

        exponent = exponent / new BigInt("2");        
        baseValue = (baseValue * baseValue) % modulus;
    }

    return result;
}
// Слишком медленно

// public static BigInt ModPow(BigInt baseValue, BigInt exponent, BigInt modulus)
// {
//     baseValue = baseValue % modulus;

//     while (exponent != new BigInt("0"))
//     {
//         exponent = exponent - new BigInt("1");
//         baseValue = (baseValue * baseValue);
//     }

//     return baseValue % modulus;
// }

public static BigInt ModInverse(BigInt a, BigInt m)
{
    BigInt x, y;
    BigInt g = ExtendedGCD(a, m, out x, out y);
    
    if (g != new BigInt("1"))
        throw new ArgumentException("Inverse does not exist (GCD != 1).");

    // Приводим x к положительному остатку
    if (x.isNegative)
        x = (x + m);

    return x % m;
}
public static BigInt ExtendedGCD(BigInt a, BigInt b, out BigInt x, out BigInt y)
{
    if (b == new BigInt("0"))
    {
        x = new BigInt("1");
        y = new BigInt("0");
        return a;
    }

    BigInt x1, y1;
    BigInt gcd = ExtendedGCD(b, a % b, out x1, out y1);
    x = y1;
    y = x1 - (a / b) * y1;
    return gcd;
}
}
}