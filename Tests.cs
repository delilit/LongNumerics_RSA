using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Channels;using Longnumerics;
namespace Testes{
    public class Tester{
        public Tester(){

        }
        public void testing(){
            //logical operands overload tests.
            { // Test 1 != testing
                BigInt big_1 = new BigInt("123");
                BigInt big_2 = new BigInt("123");
                BigInt big_3 = new BigInt("12");
                BigInt big_4 = new BigInt("124");
                BigInt big_5 = new BigInt("122");
                BigInt big_6 = new BigInt("1234");
                BigInt big_7 = new BigInt("-123");
                BigInt big_8 = new BigInt("-0");
                BigInt big_9 = new BigInt("0");
                if (big_1 != big_2){
                    Console.WriteLine("Not passed a test 1.1\n");
                    return;
                }
                if ((big_1 != big_3) == false)
                {
                    Console.WriteLine("Not passed a test 1.2\n");
                    return;
                }
                if ((big_1 != big_4) == false)
                {
                    Console.WriteLine("Not passed a test 1.3\n");
                    return;
                }
                if ((big_1 != big_5) == false)
                {
                    Console.WriteLine("Not passed a test 1.4\n");
                    return;
                }
                if ((big_1 != big_6) == false)
                {
                    Console.WriteLine("Not passed a test 1.5\n");
                    return;
                }
                if ((big_1 != big_7) == false)
                {
                    Console.WriteLine("Not passed a test 1.6\n");
                    return;
                }
                if (big_8 != big_9 == true)
                {
                    Console.WriteLine("Not passed a test 1.7\n");
                    return;
                }
            }
            
            { // Test 2 == testing
                BigInt big_1 = new BigInt("123");
                BigInt big_2 = new BigInt("123");
                BigInt big_3 = new BigInt("12");
                BigInt big_4 = new BigInt("124");
                BigInt big_5 = new BigInt("122");
                BigInt big_6 = new BigInt("1234");
                BigInt big_7 = new BigInt("-123");
                BigInt big_8 = new BigInt("-0");
                BigInt big_9 = new BigInt("0");
                if ((big_1 == big_2) == false){
                    Console.WriteLine("Not passed a test 2.1\n");
                    return;
                }
                if ((big_1 == big_3))
                {
                    Console.WriteLine("Not passed a test 2.2\n");
                    return;
                }
                if ((big_1 == big_4))
                {
                    Console.WriteLine("Not passed a test 2.3\n");
                    return;
                }
                if ((big_1 == big_5))
                {
                    Console.WriteLine("Not passed a test 2.4\n");
                    return;
                }
                if ((big_1 == big_6))
                {
                    Console.WriteLine("Not passed a test 2.5\n");
                    return;
                }
                if ((big_1 == big_7))
                {
                    Console.WriteLine("Not passed a test 2.6\n");
                    return;
                }
                if (big_8 == big_9 == false)
                {
                    Console.WriteLine("Not passed a test 2.7\n");
                    return;
                }
            }
            {
                // Test 3 > testing
                BigInt big_1 = new BigInt("123");
                BigInt big_2 = new BigInt("123");
                BigInt big_3 = new BigInt("12");
                BigInt big_4 = new BigInt("124");
                BigInt big_5 = new BigInt("122");
                BigInt big_6 = new BigInt("1234");
                BigInt big_7 = new BigInt("-123");
                BigInt big_8 = new BigInt("-0");
                BigInt big_9 = new BigInt("0");
                if ((big_1 > big_2) == true){
                    Console.WriteLine("Not passed a test 3.1\n");
                    return;
                }
                if ((big_1 > big_3) == false)
                {
                    Console.WriteLine("Not passed a test 3.2\n");
                    return;
                }
                if ((big_1 > big_4) == true)
                {
                    Console.WriteLine("Not passed a test 3.3\n");
                    return;
                }
                if ((big_1 > big_5) == false)
                {
                    Console.WriteLine("Not passed a test 3.4\n");
                    return;
                }
                if ((big_1 > big_6) == true)
                {
                    Console.WriteLine("Not passed a test 3.5\n");
                    return;
                }
                if ((big_1 > big_7) == false)
                {
                    Console.WriteLine("Not passed a test 3.6\n");
                    return;
                }
                if ((big_8 > big_9) == true)
                {
                    Console.WriteLine("Not passed a test 3.7\n");
                    return;
                }
            }
                
            { // Test 4 < testing
                BigInt big_1 = new BigInt("123");
                BigInt big_2 = new BigInt("123");
                BigInt big_3 = new BigInt("12");
                BigInt big_4 = new BigInt("124");
                BigInt big_5 = new BigInt("126");
                BigInt big_6 = new BigInt("1234");
                BigInt big_7 = new BigInt("-123");
                BigInt big_8 = new BigInt("-0");
                BigInt big_9 = new BigInt("0");
                if (big_1 < big_2){
                    Console.WriteLine("Not passed a test 4.1\n");
                    return;
                }
                if ((big_1 < big_3) == true)
                {
                    Console.WriteLine("Not passed a test 4.2\n");
                    return;
                }
                if ((big_1 < big_4) == false)
                {
                    Console.WriteLine("Not passed a test 4.3\n");
                    return;
                }
                if ((big_1 < big_5) == false)
                {
                    Console.WriteLine("Not passed a test 4.4\n");
                    return;
                }
                if ((big_1 < big_6) == false)
                {
                    Console.WriteLine("Not passed a test 4.5\n");
                    return;
                }
                if ((big_1 < big_7) == true)
                {
                    Console.WriteLine("Not passed a test 4.6\n");
                    return;
                }
                if ((big_8 < big_9) == true)
                {
                    Console.WriteLine("Not passed a test 4.7\n");
                    return;
                }
            }
            {
                // Test 5 + testing.
                BigInt big_1 = new BigInt("100");
                BigInt big_2 = new BigInt("10");
                BigInt big_3 = new BigInt("-10");
                BigInt big_4 = new BigInt("-100");
                BigInt big_5 = new BigInt("1234567891234567890123456789012345678901234567890"); 
                BigInt big_6 = new BigInt("-300"); 
                
                if (big_1 + big_1 != new BigInt("200")){
                    Console.WriteLine("Not passed a test 5.1\n");
                    return;
                }
                if (big_1 + big_2 != new BigInt("110")){
                    Console.WriteLine("Not passed a test 5.2\n");
                    return;
                }
                if (big_1 + big_3 != new BigInt("90")){
                    Console.WriteLine("Not passed a test 5.3\n");
                    return;
                }
                if (big_1 + big_4 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 5.4\n");
                    return;
                }
                if (big_2 + big_5 != new BigInt("1234567891234567890123456789012345678901234567900")){
                    Console.WriteLine("Not passed a test 5.5\n");
                    return;
                }
                if (big_1 + big_6 != new BigInt("-200")){
                    Console.WriteLine("Not passed a test 5.6\n");
                    return;
                }
                if (big_6 + big_1 != new BigInt("-200")){
                    Console.WriteLine("Not passed a test 5.7\n");
                    return;
                }
            }
            // Test 5 - testing.
            {
                BigInt big_1 = new BigInt("100");
                BigInt big_2 = new BigInt("10");
                BigInt big_3 = new BigInt("-10");
                BigInt big_4 = new BigInt("-100");
                BigInt big_5 = new BigInt("1234567891234567890123456789012345678901234567890"); 
                BigInt big_6 = new BigInt("-300"); 
                
                if (big_1 - big_1 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 6.1\n");
                    return;
                }
                if (big_1 - big_2 != new BigInt("90")){
                    Console.WriteLine("Not passed a test 6.2\n");
                    return;
                }
                if (big_1 - big_3 != new BigInt("110")){
                    Console.WriteLine("Not passed a test 6.3\n");
                    return;
                }
                if (big_1 - big_4 != new BigInt("200")){
                    Console.WriteLine("Not passed a test 6.4\n");
                    return;
                }
                if (big_2 - big_5 != new BigInt("-1234567891234567890123456789012345678901234567880")){
                    Console.WriteLine("Not passed a test 6.5\n");
                    return;
                }
                if (big_1 - big_6 != new BigInt("400")){
                    Console.WriteLine("Not passed a test 6.6\n");
                    return;
                }
                if (big_6 - big_1 != new BigInt("-400")){
                    Console.WriteLine("Not passed a test 6.7\n");
                    return;
                }
            }
            // Test 7 * testing.
            {
                BigInt big_1 = new BigInt("100");
                BigInt big_2 = new BigInt("10");
                BigInt big_3 = new BigInt("-10");
                BigInt big_4 = new BigInt("-100");
                BigInt big_5 = new BigInt("1234567891234567890123456789012345678901234567890"); 
                BigInt big_6 = new BigInt("-300"); 
                
                if (big_1 * big_1 != new BigInt("10000")){
                    Console.WriteLine("Not passed a test 7.1\n");
                    return;
                }
                if (big_1 * big_2 != new BigInt("1000")){
                    Console.WriteLine("Not passed a test 7.2\n");
                    return;
                }
                if (big_1 * big_3 != new BigInt("-1000")){
                    Console.WriteLine("Not passed a test 7.3\n");
                    return;
                }
                if (big_1 * big_4 != new BigInt("-10000")){
                    Console.WriteLine("Not passed a test 7.4\n");
                    return;
                }
                if (big_2 * big_5 != new BigInt("12345678912345678901234567890123456789012345678900")){
                    Console.WriteLine("Not passed a test 7.5\n");
                    return;
                }
                if (big_1 * big_6 != new BigInt("-30000")){
                    Console.WriteLine("Not passed a test 7.6\n");
                    return;
                }
                if (big_6 * big_1 != new BigInt("-30000")){
                    Console.WriteLine("Not passed a test 7.7\n");
                    return;
                }
            }
            // Test 8 / testing.
            {
                BigInt big_1 = new BigInt("100");
                BigInt big_2 = new BigInt("10");
                BigInt big_3 = new BigInt("-10");
                BigInt big_4 = new BigInt("-100");
                BigInt big_5 = new BigInt("1234567891234567890123456789012345678901234567890"); 
                BigInt big_6 = new BigInt("-300"); 
                
                if (big_1 / big_1 != new BigInt("1")){
                    Console.WriteLine("Not passed a test 8.1\n");
                    return;
                }
                if (big_1 / big_2 != new BigInt("10")){
                    Console.WriteLine("Not passed a test 8.2\n");
                    return;
                }
                if (big_1 / big_3 != new BigInt("-10")){
                    Console.WriteLine("Not passed a test 8.3\n");
                    return;
                }
                if (big_1 / big_4 != new BigInt("-1")){
                    Console.WriteLine("Not passed a test 8.4\n");
                    return;
                }
                if (big_1 / big_5 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 8.5\n");
                    return;
                }
                if (big_1 / big_6 != new BigInt("-0")){
                    Console.WriteLine("Not passed a test 8.6\n");
                    return;
                }
            }
            // Test 9 % testing.
            {
                BigInt big_1 = new BigInt("100");
                BigInt big_2 = new BigInt("10");
                BigInt big_3 = new BigInt("-10");
                BigInt big_4 = new BigInt("-100");
                BigInt big_5 = new BigInt("1234567891234567890123456789012345678901234567890"); 
                BigInt big_6 = new BigInt("-300"); 
                
                if (big_1 % big_1 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 9.1\n");
                    return;
                }
                if (big_1 % big_2 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 9.2\n");
                    return;
                }
                if (big_1 % big_3 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 9.3\n");
                    return;
                }
                if (big_1 % big_4 != new BigInt("0")){
                    Console.WriteLine("Not passed a test 9.4\n");
                    return;
                }
                if (big_1 % big_5 != new BigInt("100")){
                    Console.WriteLine("Not passed a test 9.5\n");
                    return;
                }
                if (big_1 % big_6 != new BigInt("100")){
                    Console.WriteLine("Not passed a test 9.6\n");
                    return;
                }
            }
            {
                // Test 10 ModInverse testing.
                BigInt big_1 = new BigInt("200");
                BigInt big_2 = new BigInt("51");
                BigInt big_3 = new BigInt("9");
                BigInt big_4 = new BigInt("11");
                BigInt big_5 = new BigInt("88");
                BigInt big_6 = new BigInt("15");

                if (BigInt.ModInverse(big_1, big_2) != new BigInt("38")){
                    Console.WriteLine("Not passed a test 10.1\n");
                    return;
                }
                if (BigInt.ModInverse(big_1, big_3) != new BigInt("5")){
                    Console.WriteLine("Not passed a test 10.2\n");
                    return;
                }
                if (BigInt.ModInverse(big_1, big_4) != new BigInt("6")){
                    Console.WriteLine("Not passed a test 10.3\n");
                    return;
                }
                try{
                if (BigInt.ModInverse(big_1, big_5) != new BigInt("2")){
                    Console.WriteLine("Not passed a test 10.4\n");
                    return;
                }
                }
                catch (Exception){}
                try{
                if (BigInt.ModInverse(big_1, big_6) != new BigInt("2")){
                    Console.WriteLine("Not passed a test 10.5\n");
                    return;
                }
                }
                catch (Exception){}
            }
            // Test 11 ExtendedGCD testing.
            {
                BigInt x = new BigInt("0");
                BigInt y = new BigInt("0");
                BigInt big_1 = new BigInt("200");
                BigInt big_2 = new BigInt("51");
                BigInt big_3 = new BigInt("90");

                if (BigInt.ExtendedGCD(big_1, big_2, out x, out y) != new BigInt("1")){
                    Console.WriteLine("Not passed a test 11.1\n");
                    return;
                }
                if (x != new BigInt("-13") || y != new BigInt("51")){
                    Console.WriteLine("Not passed a test 11.2\n");
                    return;
                }
                if (BigInt.ExtendedGCD(big_1, big_3, out x, out y) != new BigInt("10")){
                    Console.WriteLine("Not passed a test 11.3\n");
                    return;
                }
            }
            // Test 12 ModPow testing.
            {
                BigInt big_1 = new BigInt("2");
                BigInt big_2 = new BigInt("3");
                BigInt big_3 = new BigInt("4");
                BigInt big_4 = new BigInt("5");
                BigInt big_5 = new BigInt("6");
                if (BigInt.ModPow(big_1, big_2, big_3) != new BigInt("0")){ // 2^3 mod 4 = 0
                    Console.WriteLine("Not passed a test 12.1\n");
                    return;
                }
                if (BigInt.ModPow(big_1, big_4, big_2) != new BigInt("2")){ // 2^5 mod 3 = 0
                    Console.WriteLine("Not passed a test 12.2\n");
                    return;
                }
                if (BigInt.ModPow(big_1, big_5, big_5) != new BigInt("4")){ // 2^6 mod 6 = 4
                    Console.WriteLine("Not passed a test 12.3\n");
                    return;
                }
            }
}
}
}
