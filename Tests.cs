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
            }
            
            { // Test 2 == testing
                BigInt big_1 = new BigInt("123");
                BigInt big_2 = new BigInt("123");
                BigInt big_3 = new BigInt("12");
                BigInt big_4 = new BigInt("124");
                BigInt big_5 = new BigInt("122");
                BigInt big_6 = new BigInt("1234");
                BigInt big_7 = new BigInt("-123");
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
            }
                
            { // Test 4 < testing
                BigInt big_1 = new BigInt("123");
                BigInt big_2 = new BigInt("123");
                BigInt big_3 = new BigInt("12");
                BigInt big_4 = new BigInt("124");
                BigInt big_5 = new BigInt("126");
                BigInt big_6 = new BigInt("1234");
                BigInt big_7 = new BigInt("-123");
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
            }
            {
                // Test 5 + testing.
                BigInt big_1 = new BigInt("100");
                BigInt big_2 = new BigInt("10");
                BigInt big_3 = new BigInt("-10");
                BigInt big_4 = new BigInt("-100");
                BigInt big_5 = new BigInt("1234567891234567890123456789012345678901234567890"); 
                
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
            }
}
}
}