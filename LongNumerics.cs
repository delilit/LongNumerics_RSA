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
        foreach (var value in this.digits){
            Console.Write($"{value}");
        }
        Console.Write("\n");
    }
    public static bool operator == (BigInt a, BigInt b){
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
            j--
        }
        result.Insert(0, sum % 10);
        carry = sum / 10;
    }
    return result;
}

private static List<int> SubtractDigits(int[] a, int[] b)
{
    // Предполагается, что a >= b по модулю
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

    // Удалить ведущие нули
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
}
}