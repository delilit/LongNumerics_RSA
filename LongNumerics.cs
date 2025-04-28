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
                    if (a.digits[i] < b.digits[i]) return false;
                }
            }
            else{
                if (a.digits.Length > b.digits.Length) return false;
                if (a.digits.Length < b.digits.Length) return true;
                for (int i = 0; i< a.digits.Length; i++){
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
                    if (a.digits[i] < b.digits[i]) return true;
                }
            }
            else{
                if (a.digits.Length > b.digits.Length) return true;
                if (a.digits.Length < b.digits.Length) return false;
                for (int i = 0; i< a.digits.Length; i++){
                    if (a.digits[i] < b.digits[i]) return false;
                }
        }
        return false;
    }

    public static BigInt operator + (BigInt a, BigInt b){                
        
        return new BigInt("1234");
    }


}
}