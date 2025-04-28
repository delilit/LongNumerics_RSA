using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;

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
    public static BigInt operator +(BigInt a, BigInt b){
        if (a.isNegative != b.isNegative){
            
        }
    }
    

}
}